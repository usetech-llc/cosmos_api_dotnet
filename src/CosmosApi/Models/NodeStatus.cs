using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class NodeStatus
    {
        /// <summary>
        /// Initializes a new instance of the
        /// NodeStatus
        /// class.
        /// </summary>
        public NodeStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// NodeStatus
        /// class.
        /// </summary>
        public NodeStatus(AplicationVersion applicationVersion = default, NodeInfo nodeInfo = default)
        {
            ApplicationVersion = applicationVersion;
            NodeInfo = nodeInfo;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "application_version")]
        public AplicationVersion ApplicationVersion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "node_info")]
        public NodeInfo NodeInfo { get; set; }

    }
}
