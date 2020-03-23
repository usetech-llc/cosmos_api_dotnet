using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class StdTxSignature
    {
        /// <summary>
        /// Initializes a new instance of the StdTxSignature class.
        /// </summary>
        public StdTxSignature()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StdTxSignature class.
        /// </summary>
        public StdTxSignature(string signature = default(string), StdTxSignaturePubKey pubKey = default(StdTxSignaturePubKey), string accountNumber = default(string), string sequence = default(string))
        {
            Signature = signature;
            PubKey = pubKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pub_key")]
        public StdTxSignaturePubKey PubKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public string Sequence { get; set; }

    }
}
