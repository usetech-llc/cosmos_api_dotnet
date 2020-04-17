using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockQuery
    {
        /// <summary>
        /// Initializes a new instance of the BlockQuery class.
        /// </summary>
        public BlockQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockQuery class.
        /// </summary>
        public BlockQuery(BlockQueryBlockMeta blockMeta, Block block)
        {
            BlockMeta = blockMeta;
            Block = block;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_meta")]
        public BlockQueryBlockMeta BlockMeta { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public Block Block { get; set; } = null!;
    }
}
