using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1bs8ry1bankAccountsAddressTransferspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1bs8ry1bankAccountsAddressTransferspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1bs8ry1bankAccountsAddressTransferspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1bs8ry1bankAccountsAddressTransferspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1bs8ry1bankAccountsAddressTransferspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), IList<Coin> amount = default(IList<Coin>))
        {
            BaseReq = baseReq;
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
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; }

    }
}
