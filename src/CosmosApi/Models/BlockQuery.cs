using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockQuery
    {
        /// <summary>
        /// Initializes a new instance of the BlockQuery class.
        /// </summary>
        public BlockQuery()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockQuery class.
        /// </summary>
        public BlockQuery(BlockQueryBlockMeta blockMeta = default(BlockQueryBlockMeta), Block block = default(Block))
        {
            BlockMeta = blockMeta;
            Block = block;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_meta")]
        public BlockQueryBlockMeta BlockMeta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public Block Block { get; set; }

    }
}
