using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Mint parameters.
    /// </summary>
    public class MintParams
    {
        /// <summary>
        /// Type of coin to mint.
        /// </summary>
        [JsonProperty("mint_denom")]
        public string MintDenom { get; set; } = null!;
        /// <summary>
        /// Maximum annual change in inflation rate.
        /// </summary>
        [JsonProperty("inflation_rate_change")]
        public BigDecimal InflationRateChange { get; set; }
        /// <summary>
        /// Maximum inflation rate.
        /// </summary>
        [JsonProperty("inflation_max")]
        public BigDecimal InflationMax { get; set; }
        /// <summary>
        /// minimum inflation rate.
        /// </summary>
        [JsonProperty("inflation_min")]
        public BigDecimal InflationMin { get; set; }
        /// <summary>
        /// Goal of percent bonded atoms.
        /// </summary>
        [JsonProperty("goal_bonded")]
        public BigDecimal GoalBonded { get; set; }
        /// <summary>
        /// Expected blocks per year.
        /// </summary>
        [JsonProperty("blocks_per_year")]
        public ulong BlocksPerYear { get; set; }

        public MintParams()
        {
        }

        public MintParams(string mintDenom, BigDecimal inflationRateChange, BigDecimal inflationMax, BigDecimal inflationMin, BigDecimal goalBonded, ulong blocksPerYear)
        {
            MintDenom = mintDenom;
            InflationRateChange = inflationRateChange;
            InflationMax = inflationMax;
            InflationMin = inflationMin;
            GoalBonded = goalBonded;
            BlocksPerYear = blocksPerYear;
        }
    }
}