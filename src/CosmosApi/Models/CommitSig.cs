using System;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class CommitSig
    {
        /// <summary>
        /// Initializes a new instance of the CommitSig
        /// class.
        /// </summary>
        public CommitSig()
        {
        }

        public CommitSig(byte[] validatorAddress, int validatorIndex, long height, int round, DateTimeOffset timestamp, SignedMsgType? type, BlockID blockId, byte[] signature)
        {
            ValidatorAddress = validatorAddress;
            ValidatorIndex = validatorIndex;
            Height = height;
            Round = round;
            Timestamp = timestamp;
            Type = type;
            BlockId = blockId;
            Signature = signature;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_index")]
        public int ValidatorIndex { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public long Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "round")]
        public int Round { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public SignedMsgType? Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public byte[] Signature { get; set; } = null!;

    }
}
