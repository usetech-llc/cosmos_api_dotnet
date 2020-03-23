using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathsu9hm2odistributionDelegatorsDelegatoraddrRewardsValidatoraddrpostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsu9hm2odistributionDelegatorsDelegatoraddrRewardsValidatoraddrpostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsu9hm2odistributionDelegatorsDelegatoraddrRewardsValidatoraddrpostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsu9hm2odistributionDelegatorsDelegatoraddrRewardsValidatoraddrpostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsu9hm2odistributionDelegatorsDelegatoraddrRewardsValidatoraddrpostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq))
        {
            BaseReq = baseReq;
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

    }
}
