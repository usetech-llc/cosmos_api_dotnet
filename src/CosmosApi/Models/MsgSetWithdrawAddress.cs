using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Msg for changing the withdraw address for a delegator (or validator self-delegation).
    /// </summary>
    public class MsgSetWithdrawAddress : IMsg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        
        [JsonProperty("withdraw_address")]
        public string WithdrawAddress { get; set; } = null!;

        public MsgSetWithdrawAddress()
        {
        }

        public MsgSetWithdrawAddress(string delegatorAddress, string withdrawAddress)
        {
            DelegatorAddress = delegatorAddress;
            WithdrawAddress = withdrawAddress;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}