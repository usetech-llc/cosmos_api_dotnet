using System;
using System.Globalization;
using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    public class BigDecimalConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            serializer.Serialize(writer, ((BigDecimal)value).ToString(CultureInfo.InvariantCulture));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            if (str == null)
            {
                return null;
            }
            return BigDecimal.Parse(str);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BigDecimal) || objectType == typeof(BigDecimal?);
        }
    }
}