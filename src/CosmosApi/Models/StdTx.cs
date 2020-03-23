using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class StdTx
    {
        /// <summary>
        /// Initializes a new instance of the StdTx class.
        /// </summary>
        public StdTx()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StdTx class.
        /// </summary>
        public StdTx(IList<string> msg = default(IList<string>), StdTxFee fee = default(StdTxFee), string memo = default(string), StdTxSignature signature = default(StdTxSignature))
        {
            Msg = msg;
            Fee = fee;
            Memo = memo;
            Signature = signature;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public IList<string> Msg { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public StdTxFee Fee { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memo")]
        public string Memo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public StdTxSignature Signature { get; set; }

    }
}
