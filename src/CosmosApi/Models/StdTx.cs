using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// StdTx is a standard way to wrap a Msg with Fee and Signatures.
    /// NOTE: the first signature is the fee payer (Signatures must not be null).
    /// </summary>
    public class StdTx : ITx
    {
        /// <summary>
        /// Initializes a new instance of the StdTx class.
        /// </summary>
        public StdTx()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StdTx class.
        /// </summary>
        public StdTx(IList<IMsg> msg, StdFee fee, string memo, IList<StdSignature> signature)
        {
            Msg = msg;
            Fee = fee;
            Memo = memo;
            Signatures = signature;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public IList<IMsg> Msg { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public StdFee Fee { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memo")]
        public string Memo { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signatures")]
        public IList<StdSignature> Signatures { get; set; } = null!;

        public IList<IMsg> GetMsgs()
        {
            return Msg;
        }
    }
}
