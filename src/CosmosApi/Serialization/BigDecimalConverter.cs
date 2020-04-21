using System;
using System.Globalization;
using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    public class BigDecimalConverter : JsonConverter<BigDecimal>
    {
        public override void WriteJson(JsonWriter writer, BigDecimal value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString(CultureInfo.InvariantCulture));
        }

        public override BigDecimal ReadJson(JsonReader reader, Type objectType, BigDecimal existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            return BigDecimal.Parse(str);
        }
    }
}