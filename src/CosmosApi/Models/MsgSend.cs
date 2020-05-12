using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// MsgSend - high level transaction of the coin module.
    /// </summary>
    public class MsgSend : IMsg
    {
        public MsgSend()
        {
        }

        public MsgSend(string fromAddress, string address, IList<Coin> amount)
        {
            FromAddress = fromAddress;
            ToAddress = address;
            Amount = amount;
        }

        [JsonProperty("from_address")]
        public string FromAddress { get; set; } = null!;
        
        [JsonProperty("to_address")]
        public string ToAddress { get; set; } = null!;
        
        [JsonProperty("amount")]
        public IList<Coin> Amount { get; set; } = null!;

        public object SignBytesObject()
        {
            return this;
        }
    }
}