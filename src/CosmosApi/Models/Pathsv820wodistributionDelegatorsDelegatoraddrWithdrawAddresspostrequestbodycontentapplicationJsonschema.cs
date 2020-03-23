using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathsv820wodistributionDelegatorsDelegatoraddrWithdrawAddresspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsv820wodistributionDelegatorsDelegatoraddrWithdrawAddresspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsv820wodistributionDelegatorsDelegatoraddrWithdrawAddresspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsv820wodistributionDelegatorsDelegatoraddrWithdrawAddresspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsv820wodistributionDelegatorsDelegatoraddrWithdrawAddresspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string withdrawAddress = default(string))
        {
            BaseReq = baseReq;
            WithdrawAddress = withdrawAddress;
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
        [JsonProperty(PropertyName = "withdraw_address")]
        public string WithdrawAddress { get; set; }

    }
}
