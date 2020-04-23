using System;
using System.Numerics;
using CosmosApi.Serialization;
using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// RedelegationEntry - entry to a Redelegation.
    /// </summary>
    public class RedelegationEntry
    {
        /// <summary>
        /// Height at which the redelegation took place.
        /// </summary>
        [JsonProperty(PropertyName = "creation_height")]
        public long CreationHeight { get; set; }

        /// <summary>
        /// Time at which the redelegation will complete.
        /// </summary>
        [JsonProperty(PropertyName = "completion_time")]
        public DateTimeOffset CompletionTime { get; set; }

        /// <summary>
        /// Initial balance when redelegation started.
        /// </summary>
        [JsonProperty(PropertyName = "initial_balance")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger InitialBalance { get; set; }

        /// <summary>
        /// Amount of destination-validator shares created by redelegation.
        /// </summary>
        [JsonProperty(PropertyName = "shares_dst")]
        public BigDecimal SharesDst { get; set; }

        public RedelegationEntry()
        {
        }

        public RedelegationEntry(long creationHeight, DateTimeOffset completionTime, BigInteger initialBalance, BigDecimal sharesDst)
        {
            CreationHeight = creationHeight;
            CompletionTime = completionTime;
            InitialBalance = initialBalance;
            SharesDst = sharesDst;
        }
    }
}
