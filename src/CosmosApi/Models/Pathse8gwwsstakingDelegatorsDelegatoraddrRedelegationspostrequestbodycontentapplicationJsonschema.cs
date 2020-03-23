using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathse8gwwsstakingDelegatorsDelegatoraddrRedelegationspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathse8gwwsstakingDelegatorsDelegatoraddrRedelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathse8gwwsstakingDelegatorsDelegatoraddrRedelegationspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathse8gwwsstakingDelegatorsDelegatoraddrRedelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathse8gwwsstakingDelegatorsDelegatoraddrRedelegationspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string delegatorAddress = default(string), string validatorSrcAddressess = default(string), string validatorDstAddress = default(string), string shares = default(string))
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddressess = validatorSrcAddressess;
            ValidatorDstAddress = validatorDstAddress;
            Shares = shares;
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
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_src_addressess")]
        public string ValidatorSrcAddressess { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_dst_address")]
        public string ValidatorDstAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shares")]
        public string Shares { get; set; }

    }
}
