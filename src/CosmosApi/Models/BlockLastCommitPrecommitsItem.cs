using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockLastCommitPrecommitsItem
    {
        /// <summary>
        /// Initializes a new instance of the BlockLastCommitPrecommitsItem
        /// class.
        /// </summary>
        public BlockLastCommitPrecommitsItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockLastCommitPrecommitsItem
        /// class.
        /// </summary>
        public BlockLastCommitPrecommitsItem(string validatorAddress = default(string), string validatorIndex = default(string), string height = default(string), string round = default(string), string timestamp = default(string), double? type = default(double?), BlockID blockId = default(BlockID), string signature = default(string))
        {
            ValidatorAddress = validatorAddress;
            ValidatorIndex = validatorIndex;
            Height = height;
            Round = round;
            Timestamp = timestamp;
            Type = type;
            BlockId = blockId;
            Signature = signature;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_index")]
        public string ValidatorIndex { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "round")]
        public string Round { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public double? Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_id")]
        public BlockID BlockId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; }

    }
}
