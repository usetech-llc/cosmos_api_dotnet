using System;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class StdSignature
    {
        /// <summary>
        /// Initializes a new instance of the StdSignature class.
        /// </summary>
        public StdSignature()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StdSignature class.
        /// </summary>
        public StdSignature(string signature = default, StdTxSignaturePubKey pubKey = default, string accountNumber = default, string sequence = default)
        {
            Signature = signature;
            PubKey = pubKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        private void CustomInit()
        {
            throw new NotImplementedException();
        }

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
