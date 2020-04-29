using CosmosApi.Serialization;
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
        public Proposer(ulong proposalId, string proposerAddress)
        {
            ProposalId = proposalId;
            ProposerAddress = proposerAddress;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer")]
        public string ProposerAddress { get; set; } = null!;

    }
}
