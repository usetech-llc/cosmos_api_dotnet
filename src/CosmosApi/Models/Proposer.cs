using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Proposer
    {
        /// <summary>
        /// Initializes a new instance of the Proposer class.
        /// </summary>
        public Proposer()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Proposer class.
        /// </summary>
        public Proposer(string proposalId = default(string), string proposerProperty = default(string))
        {
            ProposalId = proposalId;
            ProposerProperty = proposerProperty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public string ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer")]
        public string ProposerProperty { get; set; }

    }
}
