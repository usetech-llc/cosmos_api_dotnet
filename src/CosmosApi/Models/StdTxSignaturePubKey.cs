using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class StdTxSignaturePubKey
    {
        /// <summary>
        /// Initializes a new instance of the StdTxSignaturePubKey class.
        /// </summary>
        public StdTxSignaturePubKey()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StdTxSignaturePubKey class.
        /// </summary>
        public StdTxSignaturePubKey(string type, string value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = null!;

    }
}
