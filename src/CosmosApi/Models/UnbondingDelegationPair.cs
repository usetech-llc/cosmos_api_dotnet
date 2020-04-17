using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class UnbondingDelegationPair
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingDelegationPair class.
        /// </summary>
        public UnbondingDelegationPair()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingDelegationPair class.
        /// </summary>
        public UnbondingDelegationPair(string delegatorAddress, string validatorAddress, IList<UnbondingEntries> entries)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Entries = entries;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public IList<UnbondingEntries> Entries { get; set; } = null!;

    }
}
