using System;
using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// StdFee includes the amount of coins paid in fees and the maximum
    /// gas to be used by the transaction. The ratio yields an effective "gasprice",
    /// which must be above some miminum to be accepted into the mempool.
    /// </summary>
    public class StdFee
    {
        /// <summary>
        /// Initializes a new instance of the StdFee class.
        /// </summary>
        public StdFee()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StdFee class.
        /// </summary>
        public StdFee(ulong gas, IList<Coin> amount)
        {
            Gas = gas;
            Amount = amount;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong Gas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; } = null!;

    }
}
