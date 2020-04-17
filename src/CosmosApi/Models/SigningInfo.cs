using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class SigningInfo
    {
        /// <summary>
        /// Initializes a new instance of the SigningInfo class.
        /// </summary>
        public SigningInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SigningInfo class.
        /// </summary>
        public SigningInfo(string startHeight, string indexOffset, string jailedUntil, string missedBlocksCounter)
        {
            StartHeight = startHeight;
            IndexOffset = indexOffset;
            JailedUntil = jailedUntil;
            MissedBlocksCounter = missedBlocksCounter;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "start_height")]
        public string StartHeight { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "index_offset")]
        public string IndexOffset { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jailed_until")]
        public string JailedUntil { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "missed_blocks_counter")]
        public string MissedBlocksCounter { get; set; } = null!;

    }
}
