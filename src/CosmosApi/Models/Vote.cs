using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Vote
    {
        /// <summary>
        /// Initializes a new instance of the Vote class.
        /// </summary>
        public Vote()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Vote class.
        /// </summary>
        public Vote(string voter = default(string), string proposalId = default(string), string option = default(string))
        {
            Voter = voter;
            ProposalId = proposalId;
            Option = option;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voter")]
        public string Voter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public string ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "option")]
        public string Option { get; set; }

    }
}
