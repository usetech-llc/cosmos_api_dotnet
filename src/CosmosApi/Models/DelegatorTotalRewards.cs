using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DelegatorTotalRewards
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rewards")]
        public IList<DelegationDelegatorReward> Rewards { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public IList<DecCoin> Total { get; set; } = null!;
        
        /// <summary>
        /// Initializes a new instance of the DelegatorTotalRewards class.
        /// </summary>
        public DelegatorTotalRewards()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DelegatorTotalRewards class.
        /// </summary>
        public DelegatorTotalRewards(IList<DelegationDelegatorReward> rewards, IList<DecCoin> total)
        {
            Rewards = rewards;
            Total = total;
        }
    }
}
