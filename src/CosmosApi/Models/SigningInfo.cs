using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class SigningInfo
    {
        /// <summary>
        /// Initializes a new instance of the SigningInfo class.
        /// </summary>
        public SigningInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SigningInfo class.
        /// </summary>
        public SigningInfo(string startHeight = default(string), string indexOffset = default(string), string jailedUntil = default(string), string missedBlocksCounter = default(string))
        {
            StartHeight = startHeight;
            IndexOffset = indexOffset;
            JailedUntil = jailedUntil;
            MissedBlocksCounter = missedBlocksCounter;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "start_height")]
        public string StartHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "index_offset")]
        public string IndexOffset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jailed_until")]
        public string JailedUntil { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "missed_blocks_counter")]
        public string MissedBlocksCounter { get; set; }

    }
}
