using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TxQuery
    {
        /// <summary>
        /// Initializes a new instance of the TxQuery class.
        /// </summary>
        public TxQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TxQuery class.
        /// </summary>
        public TxQuery(string txhash = default, long? height = default, StdTx tx = default, TxQueryResult result = default)
        {
            Txhash = txhash;
            Height = height;
            Tx = tx;
            Result = result;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public long? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Txhash")]
        public string Txhash { get; set; }
        
        [JsonProperty(PropertyName = "code")]
        public uint Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        public StdTx Tx { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public TxQueryResult Result { get; set; }

    }
}
