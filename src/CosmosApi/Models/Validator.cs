using System;
using System.Numerics;
using CosmosApi.Serialization;
using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Validator defines the total amount of bond shares and their exchange rate to
    /// coins. Slashing results in a decrease in the exchange rate, allowing correct
    /// calculation of future undelegations without iterating over delegators.
    /// When coins are delegated to this validator, the validator is credited with a
    /// delegation whose number of bond shares is based on the amount of coins delegated
    /// divided by the current exchange rate. Voting power can be calculated as total
    /// bonded shares multiplied by exchange rate.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Address of the validator's operator; bech encoded in JSON.
        /// </summary>
        [JsonProperty("operator_address")]
        public string OperatorAddress { get; set; } = null!;
        /// <summary>
        /// The consensus public key of the validator; bech encoded in JSON.
        /// </summary>
        [JsonProperty("consensus_pubkey")]
        public string ConsPubKey { get; set; } = null!;
        /// <summary>
        /// Has the validator been jailed from bonded status.
        /// </summary>
        [JsonProperty("jailed")]
        public bool Jailed { get; set; }
        /// <summary>
        /// Validator status (bonded/unbonding/unbonded).
        /// </summary>
        [JsonProperty("status")]
        public BondStatus Status { get; set; }
        /// <summary>
        /// delegated tokens (incl. self-delegation).
        /// </summary>
        [JsonProperty("tokens")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger Tokens { get; set; }
        /// <summary>
        /// Total shares issued to a validator's delegators. 
        /// </summary>
        [JsonProperty("delegator_shares")]
        public BigDecimal DelegatorShares { get; set; }
        /// <summary>
        /// Description terms for the validator.
        /// </summary>
        /// <returns></returns>
        [JsonProperty("description")]
        public ValidatorDescription Description { get; set; } = null!;
        /// <summary>
        /// If unbonding, height at which this validator has begun unbonding.
        /// </summary>
        [JsonProperty("unbonding_height")]
        public long UnbondingHeight { get; set; }
        /// <summary>
        /// If unbonding, min time for the validator to complete unbonding. 
        /// </summary>
        [JsonProperty("unbonding_time")]
        public DateTimeOffset UnbondingCompletionTime { get; set; }
        /// <summary>
        /// Commission parameters.
        /// </summary>
        [JsonProperty("commission")]
        public ValidatorCommission Commission { get; set; } = null!;
        /// <summary>
        /// Validator's self declared minimum self delegation.
        /// </summary>
        [JsonProperty("min_self_delegation")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger MinSelfDelegation { get; set; }

        public Validator()
        {
        }

        public Validator(string operatorAddress, string consPubKey, bool jailed, BondStatus status, BigInteger tokens, BigDecimal delegatorShares, ValidatorDescription description, long unbondingHeight, DateTimeOffset unbondingCompletionTime, ValidatorCommission commission, BigInteger minSelfDelegation)
        {
            OperatorAddress = operatorAddress;
            ConsPubKey = consPubKey;
            Jailed = jailed;
            Status = status;
            Tokens = tokens;
            DelegatorShares = delegatorShares;
            Description = description;
            UnbondingHeight = unbondingHeight;
            UnbondingCompletionTime = unbondingCompletionTime;
            Commission = commission;
            MinSelfDelegation = minSelfDelegation;
        }
    }
}
