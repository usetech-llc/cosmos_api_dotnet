using System;
using System.Globalization;
using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    public class StringNumberConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var str = Convert.ToString(value, CultureInfo.InvariantCulture);
  
            serializer.Serialize(writer, str);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(IConvertible)) || objectType.IsSubclassOf(typeof(IFormattable));
        }
    }
}