using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Description - description fields for a validator.
    /// </summary>
    public class ValidatorDescription
    {
        /// <summary>
        /// Name.
        /// </summary>
        /// <returns></returns>
        [JsonProperty("moniker")]
        public string Moniker { get; set; } = null!;
        /// <summary>
        /// Optional identity signature (ex. UPort or Keybase).
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; set; } = null!;
        /// <summary>
        /// Optional website link.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; } = null!;
        /// <summary>
        /// Optional details.
        /// </summary>
        [JsonProperty("details")]
        public string Details { get; set; } = null!;

        public ValidatorDescription()
        {
        }

        public ValidatorDescription(string moniker, string identity, string website, string details)
        {
            Moniker = moniker;
            Identity = identity;
            Website = website;
            Details = details;
        }
    }
}
