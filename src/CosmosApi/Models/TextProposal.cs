using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class TextProposal
    {
        /// <summary>
        /// Initializes a new instance of the TextProposal class.
        /// </summary>
        public TextProposal()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TextProposal class.
        /// </summary>
        public TextProposal(int? proposalId = default(int?), string title = default(string), string description = default(string), string proposalType = default(string), string proposalStatus = default(string), TallyResult finalTallyResult = default(TallyResult), string submitTime = default(string), IList<Coin> totalDeposit = default(IList<Coin>), string votingStartTime = default(string))
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
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public int? ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_type")]
        public string ProposalType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_status")]
        public string ProposalStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "final_tally_result")]
        public TallyResult FinalTallyResult { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "submit_time")]
        public string SubmitTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_deposit")]
        public IList<Coin> TotalDeposit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voting_start_time")]
        public string VotingStartTime { get; set; }

    }
}
