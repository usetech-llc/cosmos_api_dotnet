using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Redelegation contains the list of a particular delegator's
    /// redelegating bonds from a particular source validator to a
    /// particular destination validator
    /// </summary>
    public class Redelegation
    {
        public Redelegation()
        {
        }

        public Redelegation(string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, IList<RedelegationEntry> entries)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Entries = entries;
        }

        /// <summary>
        /// Delegator.
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// Validator redelegation source operator addr.
        /// </summary>
        [JsonProperty(PropertyName = "validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;

        /// <summary>
        /// Validator redelegation destination operator addr.
        /// </summary>
        [JsonProperty(PropertyName = "validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;

        /// <summary>
        /// Redelegation entries.
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public IList<RedelegationEntry> Entries { get; set; } = null!;

    }
}
