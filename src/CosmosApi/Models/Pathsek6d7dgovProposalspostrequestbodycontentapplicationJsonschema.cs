using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathsek6d7dgovProposalspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsek6d7dgovProposalspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsek6d7dgovProposalspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsek6d7dgovProposalspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsek6d7dgovProposalspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string title = default(string), string description = default(string), string proposalType = default(string), string proposer = default(string), IList<Coin> initialDeposit = default(IList<Coin>))
        {
            BaseReq = baseReq;
            Title = title;
            Description = description;
            ProposalType = proposalType;
            Proposer = proposer;
            InitialDeposit = initialDeposit;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "base_req")]
        public BaseReq BaseReq { get; set; }

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
        [JsonProperty(PropertyName = "proposer")]
        public string Proposer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initial_deposit")]
        public IList<Coin> InitialDeposit { get; set; }

    }
}
