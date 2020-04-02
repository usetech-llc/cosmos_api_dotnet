using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CosmosApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CosmosApi.Serialization
{
    public class TypeValueConverter : JsonConverter
    {
        private Dictionary<Type, string> _typeToJsonName = new Dictionary<Type, string>();
        private Dictionary<string, Type> _jsonNameToType = new Dictionary<string, Type>();

        public void AddType<T>(string jsonName)
        {
            _jsonNameToType[jsonName] = typeof(T);
            _typeToJsonName[typeof(T)] = jsonName;
        }
        
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var converter = serializer.Converters.OfType<TypeValueConverter>().First();
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var wrappedValue = value.GetType().GetProperty(nameof(TypeValue<object>.Value))?.GetValue(value);
            if (wrappedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            
            serializer.Serialize(writer, new
            {
                type = converter._typeToJsonName[wrappedValue.GetType()],
                value = wrappedValue
            });
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var converter = serializer.Converters.OfType<TypeValueConverter>().First();
            var jobject = serializer.Deserialize<JObject>(reader);
            if (jobject == null)
            {
                return null;
            }

            var typeString = jobject["type"].Value<string>();
            var type = converter._jsonNameToType[typeString];
            var typeValue = objectType.GetConstructor(new Type[0])?.Invoke(new object?[0]);
            if (typeValue == null)
            {
                throw new CosmosSerializationException($"Type {objectType.FullName} doesn't have parameterless constructor.");
            }

            var value = serializer.Deserialize(jobject["value"].CreateReader(), type);
            typeValue.GetType().GetProperty(nameof(TypeValue<object>.Value))?.SetValue(typeValue, value);
            return typeValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(TypeValue<>));
        }
    }
}