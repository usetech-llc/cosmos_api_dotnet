using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ProtocolVersion
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ProtocolVersion
        /// class.
        /// </summary>
        public ProtocolVersion()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ProtocolVersion
        /// class.
        /// </summary>
        public ProtocolVersion(ulong p2p = default(ulong), ulong block = default(ulong), ulong app = default(ulong))
        {
            P2p = p2p;
            Block = block;
            App = app;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
