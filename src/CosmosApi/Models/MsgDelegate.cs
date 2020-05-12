using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class MsgDelegate : IMsg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;
        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;

        public MsgDelegate()
        {
        }

        public MsgDelegate(string delegatorAddress, string validatorAddress, Coin amount)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Amount = amount;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}