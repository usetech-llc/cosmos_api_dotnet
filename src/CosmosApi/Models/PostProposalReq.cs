using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// PostProposalReq defines the properties of a proposal request's body.
    /// </summary>
    public class PostProposalReq
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        
        /// <summary>
        /// Title of the proposal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        
        /// <summary>
        /// Description of the proposal.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = null!;
        
        /// <summary>
        /// Type of proposal.
        /// </summary>
        [JsonProperty("proposal_type")]
        public string ProposalType { get; set; } = null!;
        
        /// <summary>
        /// Address of the proposer.
        /// </summary>
        [JsonProperty("proposer")]
        public string Proposer { get; set; } = null!;

        /// <summary>
        /// Coins to add to the proposal's deposit.
        /// </summary>
        [JsonProperty("initial_deposit")]
        public IList<Coin> InitialDeposit { get; set; } = null!;

        public PostProposalReq()
        {
        }

        public PostProposalReq(BaseReq baseReq, string title, string description, string proposalType, string proposer, IList<Coin> initialDeposit)
        {
            BaseReq = baseReq;
            Title = title;
            Description = description;
            ProposalType = proposalType;
            Proposer = proposer;
            InitialDeposit = initialDeposit;
        }
    }
}