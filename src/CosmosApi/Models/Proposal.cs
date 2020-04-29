using System;
using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Proposal
    {
        [JsonProperty("content")]
        public IProposalContent Content { get; set; } = null!;

        [JsonProperty("id")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }

        [JsonProperty("proposal_status")]
        public ProposalStatus Status { get; set; }
        
        [JsonProperty("final_tally_result")]
        public TallyResult FinalTallyResult { get; set; } = null!;

        [JsonProperty("submit_time")]
        public DateTimeOffset SubmitTime { get; set; }
        
        [JsonProperty("deposit_end_time")]
        public DateTimeOffset DepositEndTime { get; set; }
        
        [JsonProperty("total_deposit")]
        public IList<Coin> TotalDeposit { get; set; } = null!;

        [JsonProperty("voting_start_time")]
        public DateTimeOffset VotingStartTime { get; set; }
        
        [JsonProperty("voting_end_time")]
        public DateTimeOffset VotingEndTime { get; set; }

        public Proposal()
        {
        }

        public Proposal(IProposalContent content, ulong proposalId, ProposalStatus status, TallyResult finalTallyResult, DateTimeOffset submitTime, DateTimeOffset depositEndTime, IList<Coin> totalDeposit, DateTimeOffset votingStartTime, DateTimeOffset votingEndTime)
        {
            Content = content;
            ProposalId = proposalId;
            Status = status;
            FinalTallyResult = finalTallyResult;
            SubmitTime = submitTime;
            DepositEndTime = depositEndTime;
            TotalDeposit = totalDeposit;
            VotingStartTime = votingStartTime;
            VotingEndTime = votingEndTime;
        }
    }
}
