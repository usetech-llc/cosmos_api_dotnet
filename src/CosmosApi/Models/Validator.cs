using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Validator
    {
        /// <summary>
        /// Initializes a new instance of the Validator class.
        /// </summary>
        public Validator()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Validator class.
        /// </summary>
        public Validator(string operatorAddress = default(string), string consensusPubkey = default(string), bool? jailed = default(bool?), int? status = default(int?), string tokens = default(string), string delegatorShares = default(string), ValidatorDescription description = default(ValidatorDescription), string bondHeight = default(string), int? bondIntraTxCounter = default(int?), string unbondingHeight = default(string), string unbondingTime = default(string), ValidatorCommission commission = default(ValidatorCommission))
        {
            OperatorAddress = operatorAddress;
            ConsensusPubkey = consensusPubkey;
            Jailed = jailed;
            Status = status;
            Tokens = tokens;
            DelegatorShares = delegatorShares;
            Description = description;
            BondHeight = bondHeight;
            BondIntraTxCounter = bondIntraTxCounter;
            UnbondingHeight = unbondingHeight;
            UnbondingTime = unbondingTime;
            Commission = commission;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "operator_address")]
        public string OperatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "consensus_pubkey")]
        public string ConsensusPubkey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jailed")]
        public bool? Jailed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int? Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tokens")]
        public string Tokens { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_shares")]
        public string DelegatorShares { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public ValidatorDescription Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bond_height")]
        public string BondHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bond_intra_tx_counter")]
        public int? BondIntraTxCounter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unbonding_height")]
        public string UnbondingHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unbonding_time")]
        public string UnbondingTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "commission")]
        public ValidatorCommission Commission { get; set; }

    }
}
