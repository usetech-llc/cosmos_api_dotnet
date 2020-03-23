using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class TxQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the TxQueryResult class.
        /// </summary>
        public TxQueryResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TxQueryResult class.
        /// </summary>
        public TxQueryResult(string log = default(string), string gasWanted = default(string), string gasUsed = default(string), IList<KVPair> tags = default(IList<KVPair>))
        {
            Log = log;
            GasWanted = gasWanted;
            GasUsed = gasUsed;
            Tags = tags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "log")]
        public string Log { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_wanted")]
        public string GasWanted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_used")]
        public string GasUsed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<KVPair> Tags { get; set; }

    }
}
