using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockQueryBlockMeta
    {
        /// <summary>
        /// Initializes a new instance of the BlockQueryBlockMeta class.
        /// </summary>
        public BlockQueryBlockMeta()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockQueryBlockMeta class.
        /// </summary>
        public BlockQueryBlockMeta(BlockHeader header, BlockID blockId)
        {
            Header = header;
            BlockId = blockId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "header")]
        public BlockHeader Header { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; } = null!;

    }
}
