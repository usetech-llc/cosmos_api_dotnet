using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class UnbondingDelegation
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation(string delegatorAddress = default(string), string validatorAddress = default(string), string initialBalance = default(string), string balance = default(string), int? creationHeight = default(int?), int? minTime = default(int?))
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            InitialBalance = initialBalance;
            Balance = balance;
            CreationHeight = creationHeight;
            MinTime = minTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initial_balance")]
        public string InitialBalance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "creation_height")]
        public int? CreationHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "min_time")]
        public int? MinTime { get; set; }

    }
}
