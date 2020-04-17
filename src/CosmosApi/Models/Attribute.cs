using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Attribute defines an attribute wrapper where the key and value are
    /// strings instead of raw bytes.
    /// </summary>
    public class Attribute
    {
        public Attribute()
        {
        }
        
        public Attribute(string key, string value)
        {
            Key = key;
            Value = value;
        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; } = null!;

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = null!;
    }
}