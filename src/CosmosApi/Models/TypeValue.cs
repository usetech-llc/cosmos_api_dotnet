using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    [JsonConverter(typeof(TypeValueConverter))]
    public class TypeValue<TValue> where TValue : class
    {
        /// <summary>
        /// Initializes a new instance of the
        /// TypeValue
        /// class.
        /// </summary>
        public TypeValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// TypeValue
        /// class.
        /// </summary>
        public TypeValue(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public TValue Value { get; set; } = null!;

    }
}
