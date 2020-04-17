using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class NodeInfo
    {
        /// <summary>
        /// Initializes a new instance of the
        /// NodeInfo
        /// class.
        /// </summary>
        public NodeInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// NodeInfo
        /// class.
        /// </summary>
        /// <param name="version">Tendermint version</param>
        /// <param name="other">more information on versions</param>
        public NodeInfo(string id, string moniker, ProtocolVersion protocolVersion, string network, string channels, string listenAddr, string version, OtherVersionsInformation other)
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
        public string Id { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moniker")]
        public string Moniker { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "protocol_version")]
        public ProtocolVersion ProtocolVersion { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "channels")]
        public string Channels { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "listen_addr")]
        public string ListenAddr { get; set; } = null!;

        /// <summary>
        /// Gets or sets tendermint version
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; } = null!;

        /// <summary>
        /// Gets or sets more information on versions
        /// </summary>
        [JsonProperty(PropertyName = "other")]
        public OtherVersionsInformation Other { get; set; } = null!;

    }
}
