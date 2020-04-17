using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ProtocolVersion
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ProtocolVersion
        /// class.
        /// </summary>
        public ProtocolVersion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ProtocolVersion
        /// class.
        /// </summary>
        public ProtocolVersion(ulong p2p, ulong block, ulong app)
        {
            P2p = p2p;
            Block = block;
            App = app;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "p2p")]
        public ulong P2p { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public ulong Block { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "app")]
        public ulong App { get; set; }

    }
}
