using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// RedelegateRequest defines the properties of a redelegate request's body.
    /// </summary>
    public class RedelegateRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        [JsonProperty("validator_src_address")]
        public string ValidatorSrcAddress { get; set; } = null!;
        [JsonProperty("validator_dst_address")]
        public string ValidatorDstAddress { get; set; } = null!;
        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;

        public RedelegateRequest()
        {
        }

        public RedelegateRequest(BaseReq baseReq, string delegatorAddress, string validatorSrcAddress, string validatorDstAddress, Coin amount)
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorSrcAddress = validatorSrcAddress;
            ValidatorDstAddress = validatorDstAddress;
            Amount = amount;
        }
    }
}