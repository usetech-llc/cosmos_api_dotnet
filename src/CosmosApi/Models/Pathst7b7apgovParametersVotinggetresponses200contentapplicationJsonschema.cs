using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathst7b7apgovParametersVotinggetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathst7b7apgovParametersVotinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathst7b7apgovParametersVotinggetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathst7b7apgovParametersVotinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathst7b7apgovParametersVotinggetresponses200contentapplicationJsonschema(string votingPeriod = default(string))
        {
            VotingPeriod = votingPeriod;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voting_period")]
        public string VotingPeriod { get; set; }

    }
}
