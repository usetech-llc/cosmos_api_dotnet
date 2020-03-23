using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockHeader
    {
        /// <summary>
        /// Initializes a new instance of the BlockHeader class.
        /// </summary>
        public BlockHeader()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockHeader class.
        /// </summary>
        public BlockHeader(string chainId = default(string), double? height = default(double?), string time = default(string), double? numTxs = default(double?), BlockID lastBlockId = default(BlockID), double? totalTxs = default(double?), string lastCommitHash = default(string), string dataHash = default(string), string validatorsHash = default(string), string nextValidatorsHash = default(string), string consensusHash = default(string), string appHash = default(string), string lastResultsHash = default(string), string evidenceHash = default(string), string proposerAddress = default(string), BlockHeaderVersion version = default(BlockHeaderVersion))
        {
            ChainId = chainId;
            Height = height;
            Time = time;
            NumTxs = numTxs;
            LastBlockId = lastBlockId;
            TotalTxs = totalTxs;
            LastCommitHash = lastCommitHash;
            DataHash = dataHash;
            ValidatorsHash = validatorsHash;
            NextValidatorsHash = nextValidatorsHash;
            ConsensusHash = consensusHash;
            AppHash = appHash;
            LastResultsHash = lastResultsHash;
            EvidenceHash = evidenceHash;
            ProposerAddress = proposerAddress;
            Version = version;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chain_id")]
        public string ChainId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "num_txs")]
        public double? NumTxs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_block_id")]
        public BlockID LastBlockId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_txs")]
        public double? TotalTxs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_commit_hash")]
        public string LastCommitHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data_hash")]
        public string DataHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validators_hash")]
        public string ValidatorsHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "next_validators_hash")]
        public string NextValidatorsHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "consensus_hash")]
        public string ConsensusHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "app_hash")]
        public string AppHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_results_hash")]
        public string LastResultsHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "evidence_hash")]
        public string EvidenceHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer_address")]
        public string ProposerAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public BlockHeaderVersion Version { get; set; }

    }
}
