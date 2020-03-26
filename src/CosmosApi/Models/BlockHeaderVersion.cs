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
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockHeaderVersion class.
        /// </summary>
        public BlockHeaderVersion(ulong block = default, ulong app = default)
        {
            Block = block;
            App = app;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        private void CustomInit()
        {
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
