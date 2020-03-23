using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class StdTxSignaturePubKey
    {
        /// <summary>
        /// Initializes a new instance of the StdTxSignaturePubKey class.
        /// </summary>
        public StdTxSignaturePubKey()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StdTxSignaturePubKey class.
        /// </summary>
        public StdTxSignaturePubKey(string type = default(string), string value = default(string))
        {
            Type = type;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
