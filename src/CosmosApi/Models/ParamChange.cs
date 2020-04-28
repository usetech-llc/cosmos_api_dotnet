using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// ParamChange defines a parameter change.
    /// </summary>
    public class ParamChange
    {
        /// <summary>
        /// Initializes a new instance of the ParamChange class.
        /// </summary>
        public ParamChange()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ParamChange class.
        /// </summary>
        public ParamChange(string subspace, string key, string subkey, string value)
        {
            Subspace = subspace;
            Key = key;
            Subkey = subkey;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subspace")]
        public string Subspace { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subkey")]
        public string Subkey { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; } = null!;

    }
}
