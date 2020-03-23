using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths2tik89govProposalsParamChangepostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths2tik89govProposalsParamChangepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths2tik89govProposalsParamChangepostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths2tik89govProposalsParamChangepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths2tik89govProposalsParamChangepostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string title = default(string), string description = default(string), string proposer = default(string), IList<Coin> deposit = default(IList<Coin>), IList<ParamChange> changes = default(IList<ParamChange>))
        {
            BaseReq = baseReq;
            Title = title;
            Description = description;
            Proposer = proposer;
            Deposit = deposit;
            Changes = changes;
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
        [JsonProperty(PropertyName = "proposer")]
        public string Proposer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deposit")]
        public IList<Coin> Deposit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "changes")]
        public IList<ParamChange> Changes { get; set; }

    }
}
