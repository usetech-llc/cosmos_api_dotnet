using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Commission defines a commission parameters for a given validator.
    /// </summary>
    public class ValidatorCommission
    {
        [JsonProperty("commission_rates")]
        public CommissionRates CommissionRates { get; set; } = null!;
        /// <summary>
        /// The last time the commission rate was changed.
        /// </summary>
        [JsonProperty("update_time")]
        public DateTimeOffset UpdateTime { get; set; }

        public ValidatorCommission()
        {
        }

        public ValidatorCommission(CommissionRates commissionRates, DateTimeOffset updateTime)
        {
            CommissionRates = commissionRates;
            UpdateTime = updateTime;
        }
    }
}
