using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Redelegation
    {
        /// <summary>
        /// Initializes a new instance of the Redelegation class.
        /// </summary>
        public Redelegation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Redelegation class.
        /// </summary>
        public Redelegation(string delegatorAddress = default(string), string validatorSrcAddress = default(string), string validatorDstAddress = default(string), IList<Redelegation> entries = default(IList<Redelegation>))
        {
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
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
        [JsonProperty(PropertyName = "validator_src_address")]
        public string ValidatorSrcAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_dst_address")]
        public string ValidatorDstAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public IList<Redelegation> Entries { get; set; }

    }
}
