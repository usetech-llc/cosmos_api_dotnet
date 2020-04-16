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
        [JsonProperty("from_address")]
        public string FromAddress { get; set; }
        
        [JsonProperty("to_address")]
        public string ToAddress { get; set; }
        
        [JsonProperty("amount")]
        public IList<Coin> Amount { get; set; }
    }
}