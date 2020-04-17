using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TextProposal
    {
        /// <summary>
        /// Initializes a new instance of the TextProposal class.
        /// </summary>
        public TextProposal()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TextProposal class.
        /// </summary>
        public TextProposal(int? proposalId, string title, string description, string proposalType, string proposalStatus, TallyResult finalTallyResult, string submitTime, IList<Coin> totalDeposit, string votingStartTime)
        {
            ProposalId = proposalId;
            Title = title;
            Description = description;
            ProposalType = proposalType;
            ProposalStatus = proposalStatus;
            FinalTallyResult = finalTallyResult;
            SubmitTime = submitTime;
            TotalDeposit = totalDeposit;
            VotingStartTime = votingStartTime;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public int? ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_type")]
        public string ProposalType { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_status")]
        public string ProposalStatus { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "final_tally_result")]
        public TallyResult FinalTallyResult { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "submit_time")]
        public string SubmitTime { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_deposit")]
        public IList<Coin> TotalDeposit { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voting_start_time")]
        public string VotingStartTime { get; set; } = null!;

    }
}
