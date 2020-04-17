using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ValidatorDescription
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorDescription class.
        /// </summary>
        public ValidatorDescription()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorDescription class.
        /// </summary>
        public ValidatorDescription(string moniker, string identity, string website, string securityContact, string details)
        {
            Moniker = moniker;
            Identity = identity;
            Website = website;
            SecurityContact = securityContact;
            Details = details;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moniker")]
        public string Moniker { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "identity")]
        public string Identity { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "security_contact")]
        public string SecurityContact { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; } = null!;

    }
}
