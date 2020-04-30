using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Param around deposits for governance.
    /// </summary>
    public class DepositParams
    {
        /// <summary>
        /// Minimum deposit for a proposal to enter voting period.
        /// </summary>
        [JsonProperty("min_deposit")]
        public IList<Coin>? MinDeposit { get; set; }
        
        /// <summary>
        /// Maximum period in nanoseconds for Atom holders to deposit on a proposal.
        /// </summary>
        [JsonProperty("max_deposit_period")]
        [JsonConverter(typeof(StringNumberConverter))]
        public long? MaxDepositPeriod { get; set; }

        public DepositParams()
        {
        }

        public DepositParams(IList<Coin>? minDeposit, long? maxDepositPeriod)
        {
            MinDeposit = minDeposit;
            MaxDepositPeriod = maxDepositPeriod;
        }
    }
}