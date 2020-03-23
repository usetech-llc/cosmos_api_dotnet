using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ParamChange
    {
        /// <summary>
        /// Initializes a new instance of the ParamChange class.
        /// </summary>
        public ParamChange()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ParamChange class.
        /// </summary>
        public ParamChange(string subspace = default(string), string key = default(string), string subkey = default(string), object value = default(object))
        {
            Subspace = subspace;
            Key = key;
            Subkey = subkey;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subspace")]
        public string Subspace { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subkey")]
        public string Subkey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

    }
}
