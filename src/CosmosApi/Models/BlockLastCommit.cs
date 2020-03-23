using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockLastCommit
    {
        /// <summary>
        /// Initializes a new instance of the BlockLastCommit class.
        /// </summary>
        public BlockLastCommit()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockLastCommit class.
        /// </summary>
        public BlockLastCommit(BlockID blockId = default(BlockID), IList<BlockLastCommitPrecommitsItem> precommits = default(IList<BlockLastCommitPrecommitsItem>))
        {
            BlockId = blockId;
            Precommits = precommits;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "precommits")]
        public IList<BlockLastCommitPrecommitsItem> Precommits { get; set; }

    }
}
