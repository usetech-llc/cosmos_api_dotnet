using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DelegationDelegatorReward
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reward")]
        public IList<DecCoin> Reward { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the DelegationDelegatorReward class.
        /// </summary>
        public DelegationDelegatorReward()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DelegationDelegatorReward class.
        /// </summary>
        public DelegationDelegatorReward(string validatorAddress, IList<DecCoin> reward)
        {
            ValidatorAddress = validatorAddress;
            Reward = reward;
        }
    }
}
