using System;
using CosmosApi.Serialization;
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
        public StdSignature(byte[] signature = default, PublicKey pubKey = default)
        {
            Signature = signature;
            PubKey = pubKey;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public byte[] Signature { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pub_key")]
        public PublicKey PubKey { get; set; }
    }
}
