using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// CommunityPoolSpendProposal spends from the community pool.
    /// </summary>
    public class CommunityPoolSpendProposal : IProposalContent
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        [JsonProperty("description")]
        public string Description { get; set; } = null!;
        [JsonProperty("recipient")]
        public string Recipient { get; set; } = null!;
        [JsonProperty("amount")]
        public IList<Coin> Amount { get; set; } = null!;

        public CommunityPoolSpendProposal()
        {
        }

        public CommunityPoolSpendProposal(string title, string description, string recipient, IList<Coin> amount)
        {
            Title = title;
            Description = description;
            Recipient = recipient;
            Amount = amount;
        }

        public string GetProposalType()
        {
            return "CommunityPoolSpend";
        }
    }
}