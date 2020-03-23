using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class KVPair
    {
        /// <summary>
        /// Initializes a new instance of the KVPair class.
        /// </summary>
        public KVPair()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KVPair class.
        /// </summary>
        public KVPair(string key = default(string), string value = default(string))
        {
            Key = key;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
