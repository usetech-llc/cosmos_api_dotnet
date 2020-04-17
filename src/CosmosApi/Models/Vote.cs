using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Vote
    {
        /// <summary>
        /// Initializes a new instance of the Vote class.
        /// </summary>
        public Vote()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Vote class.
        /// </summary>
        public Vote(string voter, string proposalId, string option)
        {
            Voter = voter;
            ProposalId = proposalId;
            Option = option;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voter")]
        public string Voter { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public string ProposalId { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "option")]
        public string Option { get; set; } = null!;

    }
}
