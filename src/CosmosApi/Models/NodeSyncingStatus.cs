using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class NodeSyncingStatus
    {
        /// <summary>
        /// Initializes a new instance of the
        /// NodeSyncingStatus
        /// class.
        /// </summary>
        public NodeSyncingStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// NodeSyncingStatus
        /// class.
        /// </summary>
        public NodeSyncingStatus(bool? syncing = default(bool?))
        {
            Syncing = syncing;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "syncing")]
        public bool? Syncing { get; set; }

    }
}
