using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockQueryBlockMeta
    {
        /// <summary>
        /// Initializes a new instance of the BlockQueryBlockMeta class.
        /// </summary>
        public BlockQueryBlockMeta()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockQueryBlockMeta class.
        /// </summary>
        public BlockQueryBlockMeta(BlockHeader header = default(BlockHeader), BlockID blockId = default(BlockID))
        {
            Header = header;
            BlockId = blockId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
