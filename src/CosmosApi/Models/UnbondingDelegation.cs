using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class UnbondingDelegation
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation(string delegatorAddress, string validatorAddress, IList<UnbondingDelegationEntry> entries)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Entries = entries;
        }

        /// <summary>
        /// Delegator.
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// Validator unbonding from operator addr.
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// unbonding delegation entries
        /// </summary>
        [JsonProperty("entries")]
        public IList<UnbondingDelegationEntry> Entries { get; set; } = null!;

    }
}
