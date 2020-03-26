using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Block
    {
        /// <summary>
        /// Initializes a new instance of the Block class.
        /// </summary>
        public Block()
        {
        }

        public Block(BlockHeader header = null, BlockData data = null, EvidenceData evidence = null, BlockLastCommit? lastCommit = null)
        {
            Header = header;
            Data = data;
            Evidence = evidence;
            LastCommit = lastCommit;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "header")]
        public BlockHeader Header { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public BlockData Data { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "evidence")]
        public EvidenceData Evidence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_commit")]
        public BlockLastCommit? LastCommit { get; set; }

    }
}
