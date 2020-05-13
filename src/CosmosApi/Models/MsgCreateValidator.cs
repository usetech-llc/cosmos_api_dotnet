using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class MsgCreateValidator : IMsg
    {
        [JsonProperty("description")]
        public ValidatorDescription Description { get; set; } = null!;
        
        [JsonProperty("commission")]
        public CommissionRates Commission { get; set; } = null!;
        
        [JsonProperty("min_self_delegation")]
        public BigInteger MinSelfDelegation { get; set; }
        
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;
        
        [JsonProperty("pubkey")]
        public string PubKey { get; set; } = null!;
        
        [JsonProperty("value")]
        public IList<Coin> Value { get; set; } = null!;

        public MsgCreateValidator()
        {
        }

        public MsgCreateValidator(ValidatorDescription description, CommissionRates commission, BigInteger minSelfDelegation, string delegatorAddress, string validatorAddress, string pubKey, IList<Coin> value)
        {
            Description = description;
            Commission = commission;
            MinSelfDelegation = minSelfDelegation;
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            PubKey = pubKey;
            Value = value;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}