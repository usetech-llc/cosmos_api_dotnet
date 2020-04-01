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
        public BlockQueryBlockMeta(BlockHeader header = default(BlockHeader), BlockID blockId = default(BlockID))
        {
            Header = header;
            BlockId = blockId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "header")]
        public BlockHeader Header { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; }

    }
}
