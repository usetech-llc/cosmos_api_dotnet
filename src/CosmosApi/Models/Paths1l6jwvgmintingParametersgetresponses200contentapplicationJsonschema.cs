using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1l6jwvgmintingParametersgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1l6jwvgmintingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1l6jwvgmintingParametersgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1l6jwvgmintingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1l6jwvgmintingParametersgetresponses200contentapplicationJsonschema(string mintDenom = default(string), string inflationRateChange = default(string), string inflationMax = default(string), string inflationMin = default(string), string goalBonded = default(string), string blocksPerYear = default(string))
        {
            MintDenom = mintDenom;
            InflationRateChange = inflationRateChange;
            InflationMax = inflationMax;
            InflationMin = inflationMin;
            GoalBonded = goalBonded;
            BlocksPerYear = blocksPerYear;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mint_denom")]
        public string MintDenom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inflation_rate_change")]
        public string InflationRateChange { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inflation_max")]
        public string InflationMax { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inflation_min")]
        public string InflationMin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "goal_bonded")]
        public string GoalBonded { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "blocks_per_year")]
        public string BlocksPerYear { get; set; }

    }
}
