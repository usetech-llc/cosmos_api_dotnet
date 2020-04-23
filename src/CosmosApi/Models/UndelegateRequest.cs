using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// UndelegateRequest defines the properties of a undelegate request's body.
    /// </summary>
    public class UndelegateRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;
        [JsonProperty("amount")]
        public Coin Amount { get; set; } = null!;

        public UndelegateRequest()
        {
        }

        public UndelegateRequest(BaseReq baseReq, string delegatorAddress, string validatorAddress, Coin amount)
        {
            BaseReq = baseReq;
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Amount = amount;
        }
    }
}