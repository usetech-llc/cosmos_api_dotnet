using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CosmosApi.Models;

namespace CosmosApi.Extensions
{
    public static class ByteArrayExtensions
    {
        [return: NotNullIfNotNull("array")] 
        public static string? ToHexString(this byte[]? array)
        {
            if (array == null)
            {
                return null;
            }
            var serializedValue = BitConverter.ToString(array).Replace("-", "");
            return serializedValue;
        }
        
        [return: NotNullIfNotNull("str")]
        public static byte[]? ParseHexString(string? str)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length == 0)
            {
                return new byte[0];
            }
            
            var value = new byte[str.Length / 2];
            var deserializedSpan = str.AsSpan();
            for (int i = 0; i < value.Length; i++)
            {
                var substring = deserializedSpan[(i * 2)..(i * 2 + 2)];
                value[i] = byte.Parse(substring, NumberStyles.HexNumber);
            }

            return value;
        }

        [return: NotNullIfNotNull("array")] 
        public static string? ToBase64String(this byte[]? array)
        {
            if (array == null)
            {
                return null;
            }

            return Convert.ToBase64String(array);
        }

        
        [return: NotNullIfNotNull("str")]
        public static byte[]? ParseBase64(string? str)
        {
            if (str == null)
            {
                return null;
            }

            return Convert.FromBase64String(str);
        }
    }
}