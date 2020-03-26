using System;
using System.Globalization;
using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    public class HexStringByteArrayConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var array = value as byte[];
            if (array == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var serializedValue = ToString(array);
            serializer.Serialize(writer, serializedValue);
        }

        public static string ToString(byte[] array)
        {
            var serializedValue = BitConverter.ToString(array).Replace("-", "");
            return serializedValue;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var deserializedString = serializer.Deserialize<string>(reader);
            if (deserializedString == null)
            {
                return null;
            }

            if (deserializedString.Length == 0)
            {
                return new byte[0];
            }

            return ToByteArray(deserializedString);
        }

        public static byte[] ToByteArray(string str)
        {
            var value = new byte[str.Length / 2];
            var deserializedSpan = str.AsSpan();
            for (int i = 0; i < value.Length; i++)
            {
                var substring = deserializedSpan[(i * 2)..(i * 2 + 2)];
                value[i] = byte.Parse(substring, NumberStyles.HexNumber);
            }

            return value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }
    }
}