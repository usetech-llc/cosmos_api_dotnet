using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1v38s7vstakingParametersgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1v38s7vstakingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1v38s7vstakingParametersgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1v38s7vstakingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1v38s7vstakingParametersgetresponses200contentapplicationJsonschema(string inflationRateChange = default(string), string inflationMax = default(string), string inflationMin = default(string), string goalBonded = default(string), string unbondingTime = default(string), int? maxValidators = default(int?), string bondDenom = default(string))
        {
            InflationRateChange = inflationRateChange;
            InflationMax = inflationMax;
            InflationMin = inflationMin;
            GoalBonded = goalBonded;
            UnbondingTime = unbondingTime;
            MaxValidators = maxValidators;
            BondDenom = bondDenom;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        [JsonProperty(PropertyName = "unbonding_time")]
        public string UnbondingTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_validators")]
        public int? MaxValidators { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bond_denom")]
        public string BondDenom { get; set; }

    }
}
