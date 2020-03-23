using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths14cblzkdistributionParametersgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths14cblzkdistributionParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths14cblzkdistributionParametersgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths14cblzkdistributionParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths14cblzkdistributionParametersgetresponses200contentapplicationJsonschema(string baseProposerReward = default(string), string bonusProposerReward = default(string), string communityTax = default(string))
        {
            BaseProposerReward = baseProposerReward;
            BonusProposerReward = bonusProposerReward;
            CommunityTax = communityTax;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "base_proposer_reward")]
        public string BaseProposerReward { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bonus_proposer_reward")]
        public string BonusProposerReward { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "community_tax")]
        public string CommunityTax { get; set; }

    }
}
