using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class MsgBeginRedelegate : IMsg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        [JsonProperty("validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;
        [JsonProperty("validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;
        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;

        public MsgBeginRedelegate()
        {
        }

        public MsgBeginRedelegate(string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, Coin amount)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Amount = amount;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}