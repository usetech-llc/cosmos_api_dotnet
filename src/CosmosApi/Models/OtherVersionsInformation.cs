using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// more information on versions
    /// </summary>
    public class OtherVersionsInformation
    {
        /// <summary>
        /// Initializes a new instance of the
        /// OtherVersionsInformation
        /// class.
        /// </summary>
        public OtherVersionsInformation()
        {
        }

        public OtherVersionsInformation(string txIndex, string rpcAddress)
        {
            TxIndex = txIndex;
            RpcAddress = rpcAddress;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx_index")]
        public string TxIndex { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rpc_address")]
        public string RpcAddress { get; set; } = null!;
    }
}
