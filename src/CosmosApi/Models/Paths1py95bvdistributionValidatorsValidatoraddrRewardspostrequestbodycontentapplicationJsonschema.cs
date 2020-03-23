using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1py95bvdistributionValidatorsValidatoraddrRewardspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1py95bvdistributionValidatorsValidatoraddrRewardspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1py95bvdistributionValidatorsValidatoraddrRewardspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1py95bvdistributionValidatorsValidatoraddrRewardspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1py95bvdistributionValidatorsValidatoraddrRewardspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq))
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
