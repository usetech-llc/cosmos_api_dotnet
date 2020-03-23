using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class DelegationDelegatorReward
    {
        /// <summary>
        /// Initializes a new instance of the DelegationDelegatorReward class.
        /// </summary>
        public DelegationDelegatorReward()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DelegationDelegatorReward class.
        /// </summary>
        public DelegationDelegatorReward(string validatorAddress = default(string), IList<Coin> reward = default(IList<Coin>))
        {
            ValidatorAddress = validatorAddress;
            Reward = reward;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reward")]
        public IList<Coin> Reward { get; set; }

    }
}
