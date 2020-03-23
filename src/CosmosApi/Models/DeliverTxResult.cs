using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public partial class DeliverTxResult
    {
        /// <summary>
        /// Initializes a new instance of the DeliverTxResult class.
        /// </summary>
        public DeliverTxResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeliverTxResult class.
        /// </summary>
        public DeliverTxResult(int? code = default(int?), string data = default(string), int? gasUsed = default(int?), int? gasWanted = default(int?), string info = default(string), string log = default(string), IList<KVPair> tags = default(IList<KVPair>))
        {
            Code = code;
            Data = data;
            GasUsed = gasUsed;
            GasWanted = gasWanted;
            Info = info;
            Log = log;
            Tags = tags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

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
        public string Info { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public string Log { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<KVPair> Tags { get; set; }

    }
}
