using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathsn8ypolstakingDelegatorsDelegatoraddrDelegationspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsn8ypolstakingDelegatorsDelegatoraddrDelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsn8ypolstakingDelegatorsDelegatoraddrDelegationspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsn8ypolstakingDelegatorsDelegatoraddrDelegationspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsn8ypolstakingDelegatorsDelegatoraddrDelegationspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string delegatorAddress = default(string), string validatorAddress = default(string), Coin delegation = default(Coin))
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Delegation = delegation;
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
        [JsonProperty(PropertyName = "delegation")]
        public Coin Delegation { get; set; }

    }
}
