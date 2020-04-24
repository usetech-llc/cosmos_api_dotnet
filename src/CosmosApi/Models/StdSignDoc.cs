using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CosmosApi.Models
{
    public class StdSignDoc
    {
        public StdSignDoc()
        {
            
        }
        
        public StdSignDoc(ulong accountNumber, string chainId, StdFee fee, string memo, IList<IMsg> messages, ulong sequence)
        {
            AccountNumber = accountNumber;
            ChainId = chainId;
            Fee = fee;
            Memo = memo;
            Messages = messages;
            Sequence = sequence;
        }

        [JsonProperty("account_number")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong AccountNumber { get; set; }
        [JsonProperty("chain_id")]
        public string ChainId { get; set; } = null!;
        [JsonProperty("fee")]
        public StdFee Fee { get; set; } = null!;
        [JsonProperty("memo")]
        public string Memo { get; set; } = null!;
        [JsonProperty("msgs")]
        public IList<IMsg> Messages { get; set; } = null!;
        [JsonProperty("sequence")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong Sequence { get; set; }
    }
}