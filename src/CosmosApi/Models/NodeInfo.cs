using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class NodeInfo
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths15t60t2nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfo
        /// class.
        /// </summary>
        public NodeInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths15t60t2nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfo
        /// class.
        /// </summary>
        /// <param name="version">Tendermint version</param>
        /// <param name="other">more information on versions</param>
        public NodeInfo(string id = default(string), string moniker = default(string), ProtocolVersion protocolVersion = default(ProtocolVersion), string network = default(string), string channels = default(string), string listenAddr = default(string), string version = default(string), OtherVersionsInformation other = default(OtherVersionsInformation))
        {
            Id = id;
            Moniker = moniker;
            ProtocolVersion = protocolVersion;
            Network = network;
            Channels = channels;
            ListenAddr = listenAddr;
            Version = version;
            Other = other;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moniker")]
        public string Moniker { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "protocol_version")]
        public ProtocolVersion ProtocolVersion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "channels")]
        public string Channels { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "listen_addr")]
        public string ListenAddr { get; set; }

        /// <summary>
        /// Gets or sets tendermint version
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets more information on versions
        /// </summary>
        [JsonProperty(PropertyName = "other")]
        public OtherVersionsInformation Other { get; set; }

    }
}
