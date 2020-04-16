using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CosmosApi.Models
{
    public class StdSignDoc
    {
        [JsonProperty("account_number")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong AccountNumber { get; set; }
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }
        [JsonProperty("fee")]
        public StdFee Fee { get; set; }
        [JsonProperty("memo")]
        public string Memo { get; set; }
        [JsonProperty("msgs")]
        public IList<TypeValue<IMsg>> Messages { get; set; }
        [JsonProperty("sequence")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong Sequence { get; set; }
    }
}