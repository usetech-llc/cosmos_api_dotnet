using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CosmosApi.Extensions;
using NaCl;
using NBitcoin.Secp256k1;

namespace CosmosApi.Crypto
{
    public class CosmosCryptoService : ICryptoService
    {
        public PrivateKey ParsePrivateKey(string encodedKey, string? passphrase)
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
            return new PrivateKey(headers.TryGetOrDefault("type"), DecryptXsalsa20(encryptedBytes, key));
            
        }

        public byte[] Sign(byte[] bytesToSign, byte[] key, string? keyType)
        {
            if (keyType == null || string.Equals("secp256k1", keyType, StringComparison.OrdinalIgnoreCase))
            {
                return SignSecp256k1(bytesToSign, key);
            }
            
            throw new NotSupportedException($"Unknown key type {keyType}");
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