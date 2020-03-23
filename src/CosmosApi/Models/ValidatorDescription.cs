using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ValidatorDescription
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorDescription class.
        /// </summary>
        public ValidatorDescription()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorDescription class.
        /// </summary>
        public ValidatorDescription(string moniker = default(string), string identity = default(string), string website = default(string), string securityContact = default(string), string details = default(string))
        {
            Moniker = moniker;
            Identity = identity;
            Website = website;
            SecurityContact = securityContact;
            Details = details;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moniker")]
        public string Moniker { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "identity")]
        public string Identity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "security_contact")]
        public string SecurityContact { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

    }
}
