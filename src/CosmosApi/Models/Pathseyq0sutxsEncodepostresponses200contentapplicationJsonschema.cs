using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathseyq0sutxsEncodepostresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathseyq0sutxsEncodepostresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathseyq0sutxsEncodepostresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathseyq0sutxsEncodepostresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathseyq0sutxsEncodepostresponses200contentapplicationJsonschema(string tx = default(string))
        {
            Tx = tx;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        public string Tx { get; set; }

    }
}
