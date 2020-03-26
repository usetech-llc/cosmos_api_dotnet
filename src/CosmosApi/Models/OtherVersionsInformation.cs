using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// more information on versions
    /// </summary>
    public partial class OtherVersionsInformation
    {
        /// <summary>
        /// Initializes a new instance of the
        /// OtherVersionsInformation
        /// class.
        /// </summary>
        public OtherVersionsInformation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// OtherVersionsInformation
        /// class.
        /// </summary>
        public OtherVersionsInformation(string txIndex = default(string), string rpcAddress = default(string))
        {
            TxIndex = txIndex;
            RpcAddress = rpcAddress;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx_index")]
        public string TxIndex { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rpc_address")]
        public string RpcAddress { get; set; }

    }
}
