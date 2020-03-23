using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathsi9eg8qgovParametersDepositgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsi9eg8qgovParametersDepositgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsi9eg8qgovParametersDepositgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsi9eg8qgovParametersDepositgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathsi9eg8qgovParametersDepositgetresponses200contentapplicationJsonschema(IList<Coin> minDeposit = default(IList<Coin>), string maxDepositPeriod = default(string))
        {
            MinDeposit = minDeposit;
            MaxDepositPeriod = maxDepositPeriod;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "min_deposit")]
        public IList<Coin> MinDeposit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_deposit_period")]
        public string MaxDepositPeriod { get; set; }

    }
}
