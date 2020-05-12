using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Msg struct for delegation withdraw from a single validator.
    /// </summary>
    public class MsgWithdrawDelegatorReward : IMsg
    {
        [JsonProperty("delegator_address")]
        public string DelegatorAddress { get; set; } = null!;
        
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        public MsgWithdrawDelegatorReward()
        {
        }

        public MsgWithdrawDelegatorReward(string delegatorAddress, string validatorAddress)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}