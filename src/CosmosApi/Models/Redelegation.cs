using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Redelegation
    {
        /// <summary>
        /// Initializes a new instance of the Redelegation class.
        /// </summary>
        public Redelegation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Redelegation class.
        /// </summary>
        public Redelegation(string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, IList<Redelegation> entries)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Entries = entries;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public IList<Redelegation> Entries { get; set; } = null!;

    }
}
