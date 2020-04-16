using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CosmosApi.Extensions;
using NaCl;

namespace CosmosApi.Crypto
{
    public class KeysParser
    {
        public static byte[] Parse(string tendermintFormat, string passphrase)
        {
            var (headers, encryptedBytes) = Unarmor(tendermintFormat);

            if (!string.Equals("bcrypt", headers.TryGetOrDefault("kdf")))
            {
                throw new NotSupportedException($"Unrecognized armor type: {headers.TryGetOrDefault("kdf")}.");
            }

            var salt = ByteArrayExtensions.ParseHexString(headers.TryGetOrDefault("salt"));
            if (salt == null)
            {
                throw new ArgumentException("Key must contain hex encoded salt.");
            }

            var key = MakeKey(salt, passphrase);
            return DecryptXsalsa20(encryptedBytes, key);
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

        
        private static byte[] MakeKey(byte[] salt, string passphrase)
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
                .ToDictionary(s => s[0], s => s[1], StringComparer.OrdinalIgnoreCase);
            using var encryptedBytesStream = new MemoryStream();
            armor.CopyTo(encryptedBytesStream);
            var encryptedBytes = encryptedBytesStream.ToArray();
            return (headers, encryptedBytes);
        }
    }
}