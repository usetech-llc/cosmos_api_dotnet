using System;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockHeader
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
        public BlockHeader(string chainId = default, long? height = default, DateTimeOffset time = default, long? numTxs = default, BlockID lastBlockId = default, long? totalTxs = default, byte[] lastCommitHash = default, byte[] dataHash = default, byte[] validatorsHash = default, byte[] nextValidatorsHash = default, byte[] consensusHash = default, byte[] appHash = default, byte[] lastResultsHash = default, byte[] evidenceHash = default, byte[] proposerAddress = default, BlockHeaderVersion version = default)
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
        private void CustomInit()
        {
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chain_id")]
        public string ChainId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public long? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "num_txs")]
        public long? NumTxs { get; set; }

        /// <summary>
        /// Prev block info.
        /// </summary>
        [JsonProperty(PropertyName = "last_block_id")]
        public BlockID LastBlockId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_txs")]
        public long? TotalTxs { get; set; }

        /// <summary>
        /// Hash of block data: commit from validators from the last block.
        /// </summary>
        [JsonProperty(PropertyName = "last_commit_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] LastCommitHash { get; set; }

        /// <summary>
        /// Hash of block data: transactions.
        /// </summary>
        [JsonProperty(PropertyName = "data_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] DataHash { get; set; }

        /// <summary>
        /// Hash from the app output from the prev block: validators for the current block.
        /// </summary>
        [JsonProperty(PropertyName = "validators_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] ValidatorsHash { get; set; }

        /// <summary>
        /// Hash from the app output from the prev block: validators for the next block.
        /// </summary>
        [JsonProperty(PropertyName = "next_validators_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] NextValidatorsHash { get; set; }

        /// <summary>
        /// Hash from the app output from the prev block: consensus params for current block.
        /// </summary>
        [JsonProperty(PropertyName = "consensus_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] ConsensusHash { get; set; }

        /// <summary>
        /// Hash from the app output from the prev block: state after txs from the previous block.
        /// </summary>
        [JsonProperty(PropertyName = "app_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] AppHash { get; set; }

        /// <summary>
        /// Root hash of all results from the txs from the previous block.
        /// </summary>
        [JsonProperty(PropertyName = "last_results_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] LastResultsHash { get; set; }

        /// <summary>
        /// Consensus info: evidence included in the block.
        /// </summary>
        [JsonProperty(PropertyName = "evidence_hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] EvidenceHash { get; set; }

        /// <summary>
        /// Consensus info: original proposer of the block.
        /// </summary>
        [JsonProperty(PropertyName = "proposer_address")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] ProposerAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public BlockHeaderVersion Version { get; set; }
    }
}
