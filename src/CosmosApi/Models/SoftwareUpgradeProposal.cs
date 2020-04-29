using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class SoftwareUpgradeProposal : IProposalContent
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        public SoftwareUpgradeProposal()
        {
        }

        public SoftwareUpgradeProposal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string GetProposalType()
        {
            return "SoftwareUpgrade";
        }
    }
}