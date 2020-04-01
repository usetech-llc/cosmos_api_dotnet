using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Attribute defines an attribute wrapper where the key and value are
    /// strings instead of raw bytes.
    /// </summary>
    public class Attribute
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}