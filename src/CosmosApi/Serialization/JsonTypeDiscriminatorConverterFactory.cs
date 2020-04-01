using System;
using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    /// <summary>
    /// Information about how to create converter for polymorphic json data using discriminator strategy.
    /// Discriminator is a property of json object, which value allows to deduce the concrete type.
    /// </summary>
    public class JsonTypeDiscriminatorConverterFactory : IConverterFactory
    {
        public JsonTypeDiscriminatorConverterFactory(Type baseType, IList<(Type SubType, string DiscriminatorValue)> subtypes, string discriminatorName)
        {
            BaseType = baseType;
            Subtypes = subtypes;
            DiscriminatorName = discriminatorName;
        }

        /// <summary>
        /// Base type used in dotnet model.
        /// </summary>
        public Type BaseType { get; }
        
        /// <summary>
        /// List of possible subtypes and their corresponding discriminator values.
        /// </summary>
        public IList<(Type SubType, string DiscriminatorValue)> Subtypes { get; }

        /// <summary>
        /// Key of discriminator json property.
        /// </summary>
        public string DiscriminatorName { get; }
        
        public JsonConverter CreateConverter()
        {
            var builder = JsonSubtypesConverterBuilder
                .Of(BaseType, DiscriminatorName);
            foreach (var (subtype, discriminatorValue) in Subtypes)
            {
                builder = builder.RegisterSubtype(subtype, discriminatorValue);
            }

            return builder
                .SerializeDiscriminatorProperty()
                .Build();
        }
    }
}