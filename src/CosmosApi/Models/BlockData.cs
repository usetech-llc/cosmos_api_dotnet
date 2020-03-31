using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockData
    {
        public BlockData(IList<string>? transactions = default)
        {
            Transactions = transactions;
        }

        [JsonProperty(PropertyName = "txs")]
        public IList<string>? Transactions { get; set; }
    }
}