using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class KVPair
    {
        /// <summary>
        /// Initializes a new instance of the KVPair class.
        /// </summary>
        public KVPair()
        {
        }

        /// <summary>
        /// Initializes a new instance of the KVPair class.
        /// </summary>
        public KVPair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = null!;

    }
}
