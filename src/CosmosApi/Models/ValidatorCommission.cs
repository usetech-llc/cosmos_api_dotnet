using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ValidatorCommission
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorCommission class.
        /// </summary>
        public ValidatorCommission()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorCommission class.
        /// </summary>
        public ValidatorCommission(string rate = default(string), string maxRate = default(string), string maxChangeRate = default(string), string updateTime = default(string))
        {
            Rate = rate;
            MaxRate = maxRate;
            MaxChangeRate = maxChangeRate;
            UpdateTime = updateTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_rate")]
        public string MaxRate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_change_rate")]
        public string MaxChangeRate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "update_time")]
        public string UpdateTime { get; set; }

    }
}
