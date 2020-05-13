using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class StakingParams
    {
        /// <summary>
        /// Nanoseconds count.
        /// </summary>
        [JsonProperty("unbonding_time")]
        public long UnbondingTime { get; set; }
        [JsonProperty("max_validators")]
        public ushort MaxValidators { get; set; }
        [JsonProperty("max_entries")]
        public ushort MaxEntries { get; set; }
        [JsonProperty("bond_denom")]
        public string BondDenom { get; set; } = null!;

        public StakingParams()
        {
        }

        public StakingParams(long unbondingTime, ushort maxValidators, ushort maxEntries, string bondDenom)
        {
            UnbondingTime = unbondingTime;
            MaxValidators = maxValidators;
            MaxEntries = maxEntries;
            BondDenom = bondDenom;
        }
    }
}