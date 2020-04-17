using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Commit contains the evidence that a block was committed by a set of validators.
    /// NOTE: Commit is empty for height 1, but never nil.
    /// </summary>
    public class BlockLastCommit
    {
        /// <summary>
        /// Initializes a new instance of the BlockLastCommit class.
        /// </summary>
        public BlockLastCommit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockLastCommit class.
        /// </summary>
        public BlockLastCommit(BlockID blockId, IList<CommitSig?>? precommits)
        {
            BlockId = blockId;
            Precommits = precommits;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "precommits")]
        public IList<CommitSig?>? Precommits { get; set; }

    }
}
