using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ValidatorSigningInfo
    {
        /// <summary>
        /// Validator consensus address. 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = null!;
        /// <summary>
        /// Height at which validator was first a candidate OR was unjailed.
        /// </summary>
        [JsonProperty("start_height")]
        public long StartHeight { get; set; }
        /// <summary>
        /// Index offset into signed block bit array. 
        /// </summary>
        [JsonProperty("index_offset")]
        public long IndexOffset { get; set; }
        /// <summary>
        /// Timestamp validator cannot be unjailed until. 
        /// </summary>
        [JsonProperty("jailed_until")]
        public DateTimeOffset JailedUntil { get; set; }
        /// <summary>
        /// Whether or not a validator has been tombstoned (killed out of validator set). 
        /// </summary>
        [JsonProperty("tombstoned")]
        public bool Tombstoned { get; set; }
        /// <summary>
        /// Missed blocks counter (to avoid scanning the array every time). 
        /// </summary>
        [JsonProperty("missed_blocks_counter")]
        public long MissedBlocksCounter { get; set; } 
        
        public ValidatorSigningInfo()
        {
        }

        public ValidatorSigningInfo(string address, long startHeight, long indexOffset, DateTimeOffset jailedUntil, bool tombstoned, long missedBlocksCounter)
        {
            Address = address;
            StartHeight = startHeight;
            IndexOffset = indexOffset;
            JailedUntil = jailedUntil;
            Tombstoned = tombstoned;
            MissedBlocksCounter = missedBlocksCounter;
        }
    }
}
