using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockData
    {
        public BlockData(List<byte[]>? transactions = default)
        {
            Transactions = transactions;
        }

        [JsonProperty(PropertyName = "txs")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public List<byte[]>? Transactions { get; set; }
    }
}