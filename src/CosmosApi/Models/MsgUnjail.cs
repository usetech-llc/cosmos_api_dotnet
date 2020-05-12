using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// MsgUnjail - for unjailing jailed validator.
    /// </summary>
    public class MsgUnjail : IMsg
    {
        /// <summary>
        /// Address of the validator operator.
        /// </summary>
        [JsonProperty("address")]
        public string ValidatorAddr { get; set; } = null!;

        public MsgUnjail()
        {
        }

        public MsgUnjail(string validatorAddr)
        {
            ValidatorAddr = validatorAddr;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}