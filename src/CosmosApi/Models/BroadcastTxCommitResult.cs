using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BroadcastTxCommitResult
    {
        /// <summary>
        /// Initializes a new instance of the BroadcastTxCommitResult class.
        /// </summary>
        public BroadcastTxCommitResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BroadcastTxCommitResult class.
        /// </summary>
        public BroadcastTxCommitResult(CheckTxResult checkTx = default(CheckTxResult), DeliverTxResult deliverTx = default(DeliverTxResult), string hash = default(string), int? height = default(int?))
        {
            CheckTx = checkTx;
            DeliverTx = deliverTx;
            Hash = hash;
            Height = height;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "check_tx")]
        public CheckTxResult CheckTx { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deliver_tx")]
        public DeliverTxResult DeliverTx { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int? Height { get; set; }

    }
}
