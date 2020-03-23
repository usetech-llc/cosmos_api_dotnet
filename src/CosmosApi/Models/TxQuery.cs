using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class TxQuery
    {
        /// <summary>
        /// Initializes a new instance of the TxQuery class.
        /// </summary>
        public TxQuery()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TxQuery class.
        /// </summary>
        public TxQuery(string hash = default(string), double? height = default(double?), StdTx tx = default(StdTx), TxQueryResult result = default(TxQueryResult))
        {
            Hash = hash;
            Height = height;
            Tx = tx;
            Result = result;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double? Height { get; set; }

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
