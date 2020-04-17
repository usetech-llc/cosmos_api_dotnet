using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TxQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the TxQueryResult class.
        /// </summary>
        public TxQueryResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TxQueryResult class.
        /// </summary>
        public TxQueryResult(string log, string gasWanted, string gasUsed, IList<KVPair> tags)
        {
            Log = log;
            GasWanted = gasWanted;
            GasUsed = gasUsed;
            Tags = tags;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public string Log { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_wanted")]
        public string GasWanted { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_used")]
        public string GasUsed { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<KVPair> Tags { get; set; } = null!;

    }
}
