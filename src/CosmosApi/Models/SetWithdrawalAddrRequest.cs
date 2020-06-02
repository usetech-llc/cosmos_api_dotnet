using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class SetWithdrawalAddrRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        
        [JsonProperty("withdraw_address")]
        public string WithdrawAddress { get; set; } = null!;

        public SetWithdrawalAddrRequest()
        {
        }

        public SetWithdrawalAddrRequest(BaseReq baseReq, string withdrawAddress)
        {
            BaseReq = baseReq;
            WithdrawAddress = withdrawAddress;
        }
    }
}