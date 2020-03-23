using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class PublicKey
    {
        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        public PublicKey()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        public PublicKey(string type = default(string), string value = default(string))
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
