using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1blgqqygovProposalsProposalidDepositspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1blgqqygovProposalsProposalidDepositspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1blgqqygovProposalsProposalidDepositspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1blgqqygovProposalsProposalidDepositspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1blgqqygovProposalsProposalidDepositspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string depositor = default(string), IList<Coin> amount = default(IList<Coin>))
        {
            BaseReq = baseReq;
            Depositor = depositor;
            Amount = amount;
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
        [JsonProperty(PropertyName = "depositor")]
        public string Depositor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; }

    }
}
