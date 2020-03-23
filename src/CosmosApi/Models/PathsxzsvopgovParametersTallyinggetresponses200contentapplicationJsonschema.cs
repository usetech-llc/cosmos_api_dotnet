using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class PathsxzsvopgovParametersTallyinggetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsxzsvopgovParametersTallyinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public PathsxzsvopgovParametersTallyinggetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsxzsvopgovParametersTallyinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public PathsxzsvopgovParametersTallyinggetresponses200contentapplicationJsonschema(string threshold = default(string), string veto = default(string), string governancePenalty = default(string))
        {
            Threshold = threshold;
            Veto = veto;
            GovernancePenalty = governancePenalty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "threshold")]
        public string Threshold { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "veto")]
        public string Veto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "governance_penalty")]
        public string GovernancePenalty { get; set; }

    }
}
