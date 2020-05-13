using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Msg for validator withdraw.
    /// </summary>
    public class MsgWithdrawValidatorCommission : IMsg
    {
        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        public MsgWithdrawValidatorCommission()
        {
        }

        public MsgWithdrawValidatorCommission(string validatorAddress)
        {
            ValidatorAddress = validatorAddress;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}