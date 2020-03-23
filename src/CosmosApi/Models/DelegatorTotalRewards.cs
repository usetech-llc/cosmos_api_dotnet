using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class DelegatorTotalRewards
    {
        /// <summary>
        /// Initializes a new instance of the DelegatorTotalRewards class.
        /// </summary>
        public DelegatorTotalRewards()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DelegatorTotalRewards class.
        /// </summary>
        public DelegatorTotalRewards(IList<DelegationDelegatorReward> rewards = default(IList<DelegationDelegatorReward>), IList<Coin> total = default(IList<Coin>))
        {
            Rewards = rewards;
            Total = total;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rewards")]
        public IList<DelegationDelegatorReward> Rewards { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public IList<Coin> Total { get; set; }

    }
}
