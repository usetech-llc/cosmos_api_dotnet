using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class PathsxtckwmstakingPoolgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsxtckwmstakingPoolgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public PathsxtckwmstakingPoolgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsxtckwmstakingPoolgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public PathsxtckwmstakingPoolgetresponses200contentapplicationJsonschema(string looseTokens = default(string), string bondedTokens = default(string), string inflationLastTime = default(string), string inflation = default(string), string dateLastCommissionReset = default(string), string prevBondedShares = default(string))
        {
            LooseTokens = looseTokens;
            BondedTokens = bondedTokens;
            InflationLastTime = inflationLastTime;
            Inflation = inflation;
            DateLastCommissionReset = dateLastCommissionReset;
            PrevBondedShares = prevBondedShares;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "loose_tokens")]
        public string LooseTokens { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bonded_tokens")]
        public string BondedTokens { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inflation_last_time")]
        public string InflationLastTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inflation")]
        public string Inflation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "date_last_commission_reset")]
        public string DateLastCommissionReset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "prev_bonded_shares")]
        public string PrevBondedShares { get; set; }

    }
}
