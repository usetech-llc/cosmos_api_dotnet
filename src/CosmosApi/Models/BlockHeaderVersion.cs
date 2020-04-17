using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockHeaderVersion
    {
        /// <summary>
        /// Initializes a new instance of the BlockHeaderVersion class.
        /// </summary>
        public BlockHeaderVersion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockHeaderVersion class.
        /// </summary>
        public BlockHeaderVersion(ulong block, ulong app)
        {
            Block = block;
            App = app;
        }

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
