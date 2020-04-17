using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class UnbondingDelegation
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingDelegation class.
        /// </summary>
        public UnbondingDelegation(string delegatorAddress, string validatorAddress, string initialBalance, string balance, int? creationHeight, int? minTime)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            InitialBalance = initialBalance;
            Balance = balance;
            CreationHeight = creationHeight;
            MinTime = minTime;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initial_balance")]
        public string InitialBalance { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; } = null!;

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
