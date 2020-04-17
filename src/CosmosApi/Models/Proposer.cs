using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Proposer
    {
        /// <summary>
        /// Initializes a new instance of the Proposer class.
        /// </summary>
        public Proposer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Proposer class.
        /// </summary>
        public Proposer(string proposalId, string proposerProperty)
        {
            ProposalId = proposalId;
            ProposerProperty = proposerProperty;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public string ProposalId { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer")]
        public string ProposerProperty { get; set; } = null!;

    }
}
