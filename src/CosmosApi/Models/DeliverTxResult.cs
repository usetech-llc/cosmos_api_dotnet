using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public class DeliverTxResult
    {
        /// <summary>
        /// Initializes a new instance of the DeliverTxResult class.
        /// </summary>
        public DeliverTxResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeliverTxResult class.
        /// </summary>
        public DeliverTxResult(int? code, string data, int? gasUsed, int? gasWanted, string info, string log, IList<KVPair> tags)
        {
            Code = code;
            Data = data;
            GasUsed = gasUsed;
            GasWanted = gasWanted;
            Info = info;
            Log = log;
            Tags = tags;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_used")]
        public int? GasUsed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_wanted")]
        public int? GasWanted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public string Log { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<KVPair> Tags { get; set; } = null!;

    }
}
