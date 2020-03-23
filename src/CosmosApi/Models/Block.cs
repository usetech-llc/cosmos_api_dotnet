using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Block
    {
        /// <summary>
        /// Initializes a new instance of the Block class.
        /// </summary>
        public Block()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Block class.
        /// </summary>
        public Block(BlockHeader header = default(BlockHeader), IList<string> txs = default(IList<string>), IList<string> evidence = default(IList<string>), BlockLastCommit lastCommit = default(BlockLastCommit))
        {
            Header = header;
            Txs = txs;
            Evidence = evidence;
            LastCommit = lastCommit;
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
        [JsonProperty(PropertyName = "txs")]
        public IList<string> Txs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "evidence")]
        public IList<string> Evidence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_commit")]
        public BlockLastCommit LastCommit { get; set; }

    }
}
