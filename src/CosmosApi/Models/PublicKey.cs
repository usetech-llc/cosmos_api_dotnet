using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class PublicKey
    {
        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        public PublicKey()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        public PublicKey(string? type, string value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = null!;
    }
}
