using CosmosApi.Serialization;
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
        public Vote(string voter, ulong proposalId, VoteOption option)
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
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "option")]
        public VoteOption Option { get; set; }

    }
}
