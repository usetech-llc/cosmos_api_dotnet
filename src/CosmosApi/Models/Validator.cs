using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Validator
    {
        /// <summary>
        /// Initializes a new instance of the Validator class.
        /// </summary>
        public Validator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Validator class.
        /// </summary>
        public Validator(string operatorAddress, string consensusPubkey, bool? jailed, int? status, string tokens, string delegatorShares, ValidatorDescription description, string bondHeight, int? bondIntraTxCounter, string unbondingHeight, string unbondingTime, ValidatorCommission commission)
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
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "operator_address")]
        public string OperatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "consensus_pubkey")]
        public string ConsensusPubkey { get; set; } = null!;

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
        public string Tokens { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_shares")]
        public string DelegatorShares { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public ValidatorDescription Description { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bond_height")]
        public string BondHeight { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bond_intra_tx_counter")]
        public int? BondIntraTxCounter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unbonding_height")]
        public string UnbondingHeight { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unbonding_time")]
        public string UnbondingTime { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "commission")]
        public ValidatorCommission Commission { get; set; } = null!;

    }
}
