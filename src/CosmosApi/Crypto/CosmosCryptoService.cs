using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CosmosApi.Extensions;
using CosmosApi.Models;
using NaCl;
using NBitcoin.Secp256k1;

namespace CosmosApi.Crypto
{
    public class CosmosCryptoService : ICryptoService
    {
        private const string Secp256k1 = "secp256k1";
        private const string Secp256k1PublicKeyType = "tendermint/PubKeySecp256k1";
        public BinaryPrivateKey ParsePrivateKey(string encodedKey, string? passphrase)
        {
            var (headers, encryptedBytes) = Unarmor(encodedKey);

            if (!string.Equals("bcrypt", headers.TryGetOrDefault("kdf")))
            {
                throw new NotSupportedException($"Unrecognized armor type: {headers.TryGetOrDefault("kdf")}.");
            }

            var salt = ByteArrayExtensions.ParseHexString(headers.TryGetOrDefault("salt"));
            if (salt == null)
            {
                throw new ArgumentException("Key must contain hex encoded salt.");
            }

            var key = MakeKeyEncryptionKey(salt, passphrase ?? throw new ArgumentNullException(nameof(passphrase)));
            return new BinaryPrivateKey(headers.TryGetOrDefault("type"), DecryptXsalsa20(encryptedBytes, key));
        }

        public BinaryPublicKey ParsePublicKey(PublicKey publicKey)
        {
            return new BinaryPublicKey(publicKey.Type, Convert.FromBase64String(publicKey.Value));
        }


        public byte[] Sign(byte[] bytesToSign, BinaryPrivateKey key)
        {
            
            if (IsSecp256k1(key.Type))
            {
                return SignSecp256k1(bytesToSign, key.Value);
            }
            
            throw new NotSupportedException($"Unknown key type {key.Type}");
        }

        public bool VerifySign(byte[] message, byte[] sign, BinaryPublicKey key)
        {
            if (IsSecp256k1(key.Type))
            {
                return IsValidSecp256k1(message, sign, key.Value);
            }

            throw new NotSupportedException($"Unknown key type {key.Type}");
        }

        public PublicKey? MakePublicKey(PublicKey? publicKey, BinaryPrivateKey privateKey)
        {
            if (publicKey?.Type != null && publicKey?.Value != null)
            {
                return publicKey;
            }
            
            if (publicKey?.Value != null)
            {
                if (IsSecp256k1(publicKey.Type))
                {
                    var parsedKey = ParseSecp256k1PublicKey(publicKey);
                    if (parsedKey != null)
                    {
                        return parsedKey;
                    } 
                }
            }
            
            if (IsSecp256k1(privateKey.Type))
            {
                return MakeSecp256k1PublicKey(privateKey.Value);
            }

            return null;
        }

        private PublicKey? ParseSecp256k1PublicKey(PublicKey publicKey)
        {
            byte[]? keyBytes = null;
            //todo: try to parse bech32 from publicKey.Value
            if(keyBytes == null)
            {
                try
                {
                    keyBytes = ByteArrayExtensions.ParseBase64(publicKey.Value);
                }
                catch
                {
                    // ignored
                }

            }
            
            if (keyBytes == null)
            {
                try
                {
                    keyBytes = ByteArrayExtensions.ParseBase64(publicKey.Value);
                }
                catch
                {
                    // ignored
                }
            }

            if (keyBytes == null)
            {
                return null;
            }

            if(Context.Instance.TryCreatePubKey(keyBytes, out var compressed, out var ecPublicKey))
            {
                var compressedBytes = ecPublicKey!.ToBytes(true);
                return new PublicKey(Secp256k1PublicKeyType, compressedBytes.ToBase64String());
            }
            return null;
        }

        private PublicKey? MakeSecp256k1PublicKey(byte[] privateKeyValue)
        {
            using var ecKey = Context.Instance.CreateECPrivKey(privateKeyValue);
            var publicKey = ecKey.CreatePubKey()
                .ToBytes(true);
            return new PublicKey(Secp256k1PublicKeyType, publicKey.ToBase64String());
        }

        private static bool IsSecp256k1(string? type)
        {
            return type == null || type.Contains(Secp256k1, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidSecp256k1(byte[] message, byte[] sign, byte[] keyValue)
        {
            if (!Context.Instance.TryCreatePubKey(keyValue, out var key))
            {
                throw new ArgumentException($"{Convert.ToBase64String(keyValue)} is not valid {Secp256k1} public key");
            }

            if (!SecpECDSASignature.TryCreateFromCompact(sign, out var secpEcdsaSignature))
            {
                throw new ArgumentException($"Sign parameter is not a valid compact {Secp256k1} signature.");
            }

            using var sha = new SHA256Managed();
            return key!.SigVerify(secpEcdsaSignature!, sha.ComputeHash(message));
        }

        internal byte[] SignSecp256k1(byte[] bytesToSign, byte[] key)
        {
            using var sha = new SHA256Managed();
            var hashed = sha.ComputeHash(bytesToSign);
            using var ecKey = Context.Instance.CreateECPrivKey(key);
            var signature = ecKey.SignECDSARFC6979(hashed);
            var signedBytes = new byte[64];
            signature.WriteCompactToSpan(signedBytes);
            return signedBytes;
        }

        private static byte[] DecryptXsalsa20(byte[] encryptedBytes, byte[] key)
        {
            var secretbox = new NaCl.XSalsa20Poly1305(key);
            var decrypted = new byte[encryptedBytes.Length - XSalsa20Poly1305.NonceLength - XSalsa20Poly1305.TagLength];
            var encryptedSpan = encryptedBytes.AsSpan();
            if(!secretbox.TryDecrypt(decrypted, encryptedSpan[XSalsa20Poly1305.NonceLength..], encryptedSpan[..XSalsa20Poly1305.NonceLength]))
            {
                throw new Exception("Failed to decrypt.");
            }

            return decrypted[^32..];
        }

        private static byte[] MakeKeyEncryptionKey(byte[] salt, string passphrase)
        {
            var bcrypted = 
                Org.BouncyCastle.Crypto.Generators.OpenBsdBCrypt.Generate("2a", passphrase.ToCharArray(), salt, 12);

            using var sha = new SHA256Managed();
            var hashed = sha.ComputeHash( Encoding.UTF8.GetBytes(bcrypted));

            return hashed;
        }

        private static (Dictionary<string, string> Headers, byte[] EncryptedBytes) Unarmor(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var inputStream = new MemoryStream(bytes);
            using var armor = new Org.BouncyCastle.Bcpg.ArmoredInputStream(inputStream);
            
            var headers = armor.GetArmorHeaders()
                .Select(h => h.Split(": ", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(s => s[0], s => s[1], (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
            using var encryptedBytesStream = new MemoryStream();
            armor.CopyTo(encryptedBytesStream);
            var encryptedBytes = encryptedBytesStream.ToArray();
            return (headers, encryptedBytes);
        }
    }
}