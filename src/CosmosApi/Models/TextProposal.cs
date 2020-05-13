using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TextProposal : IProposalContent
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        public TextProposal()
        {
        }

        public TextProposal(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string GetProposalType()
        {
            return "Text";
        }
    }
}