using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ValidatorCommission
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorCommission class.
        /// </summary>
        public ValidatorCommission()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorCommission class.
        /// </summary>
        public ValidatorCommission(string rate, string maxRate, string maxChangeRate, string updateTime)
        {
            Rate = rate;
            MaxRate = maxRate;
            MaxChangeRate = maxChangeRate;
            UpdateTime = updateTime;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_rate")]
        public string MaxRate { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_change_rate")]
        public string MaxChangeRate { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "update_time")]
        public string UpdateTime { get; set; } = null!;

    }
}
