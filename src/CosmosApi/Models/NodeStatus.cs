using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class NodeStatus
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathsy55qd0nodeInfogetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public NodeStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathsy55qd0nodeInfogetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public NodeStatus(AplicationVersion applicationVersion = default(AplicationVersion), NodeInfo nodeInfo = default(NodeInfo))
        {
            ApplicationVersion = applicationVersion;
            NodeInfo = nodeInfo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
