using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths11j5dmmstakingDelegatorsDelegatoraddrUnbondingDelegationspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths11j5dmmstakingDelegatorsDelegatoraddrUnbondingDelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths11j5dmmstakingDelegatorsDelegatoraddrUnbondingDelegationspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths11j5dmmstakingDelegatorsDelegatoraddrUnbondingDelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths11j5dmmstakingDelegatorsDelegatoraddrUnbondingDelegationspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string delegatorAddress = default(string), string validatorAddress = default(string), string shares = default(string))
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
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
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shares")]
        public string Shares { get; set; }

    }
}
