using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class UnbondingDelegationPair
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingDelegationPair class.
        /// </summary>
        public UnbondingDelegationPair()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingDelegationPair class.
        /// </summary>
        public UnbondingDelegationPair(string delegatorAddress = default(string), string validatorAddress = default(string), IList<UnbondingEntries> entries = default(IList<UnbondingEntries>))
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Entries = entries;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        [JsonProperty(PropertyName = "entries")]
        public IList<UnbondingEntries> Entries { get; set; }

    }
}
