using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1vvh3ujdistributionDelegatorsDelegatoraddrRewardspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1vvh3ujdistributionDelegatorsDelegatoraddrRewardspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1vvh3ujdistributionDelegatorsDelegatoraddrRewardspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1vvh3ujdistributionDelegatorsDelegatoraddrRewardspostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1vvh3ujdistributionDelegatorsDelegatoraddrRewardspostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq))
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
