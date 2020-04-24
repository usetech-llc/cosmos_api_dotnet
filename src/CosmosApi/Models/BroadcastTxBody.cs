using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BroadcastTxBody
    {
        /// <summary>
        /// Initializes a new instance of the
        /// BroadcastTxBody class.
        /// </summary>
        public BroadcastTxBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// BroadcastTxBody class.
        /// </summary>
        public BroadcastTxBody(ITx tx, BroadcastTxMode mode)
        {
            Tx = tx;
            Mode = mode;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        [JsonConverter(typeof(TypeValueConverter<ITx>), true)]
        public ITx Tx { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public BroadcastTxMode Mode { get; set; }

    }
}
