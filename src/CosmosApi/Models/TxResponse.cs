using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// TxResponse defines a structure containing relevant tx data and metadata. The
    /// tags are stringified and the log is JSON decoded.
    /// </summary>
    public class TxResponse
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public long Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "txhash")]
        public string TxHash { get; set; } = null!;
        
        [JsonProperty(PropertyName = "code")]
        public uint Code { get; set; }
        
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; } = null!;
        
        [JsonProperty(PropertyName = "raw_log")]
        public string RawLog { get; set; } = null!;
        
        [JsonProperty(PropertyName = "logs")]
        public IList<ABCIMessageLog> Logs { get; set; } = null!;
        
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; } = null!;
        
        [JsonProperty(PropertyName = "gas_wanted")]
        public long GasWanted { get; set; }
        
        [JsonProperty(PropertyName = "gas_used")]
        public long GasUsed { get; set; }
        
        [JsonProperty(PropertyName = "codespace")]
        public string Codespace { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        public ITx Tx { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        public TxResponse()
        {
        }

        public TxResponse(long height, string txHash, uint code, string data, string rawLog, IList<ABCIMessageLog> logs, string info, long gasWanted, long gasUsed, string codespace, ITx tx, DateTimeOffset timestamp)
        {
            Height = height;
            TxHash = txHash;
            Code = code;
            Data = data;
            RawLog = rawLog;
            Logs = logs;
            Info = info;
            GasWanted = gasWanted;
            GasUsed = gasUsed;
            Codespace = codespace;
            Tx = tx;
            Timestamp = timestamp;
        }
    }
}
