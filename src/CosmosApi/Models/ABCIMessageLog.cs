using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// ABCIMessageLog defines a structure containing an indexed tx ABCI message log.
    /// </summary>
    public class ABCIMessageLog
    {
        
        [JsonProperty(PropertyName = "msg_index")]
        public ushort MsgIndex { get; set; }
        
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        
        [JsonProperty(PropertyName = "log")]
        public string? Log { get; set; }
        
        /// <summary>
        /// Events contains a slice of Event objects that were emitted during some
        /// execution.
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<StringEvent>? Events { get; set; }

        public ABCIMessageLog()
        {
        }

        public ABCIMessageLog(ushort msgIndex, bool success, string? log, IList<StringEvent>? events)
        {
            MsgIndex = msgIndex;
            Success = success;
            Log = log;
            Events = events;
        }
    }
}
