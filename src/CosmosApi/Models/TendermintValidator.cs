using System;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public class TendermintValidator
    {
        /// <summary>
        /// Initializes a new instance of the TendermintValidator class.
        /// </summary>
        public TendermintValidator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TendermintValidator class.
        /// </summary>
        public TendermintValidator(byte[] address, string pubKey, long votingPower, long proposerPriority)
        {
            Address = address;
            PubKey = pubKey;
            VotingPower = votingPower;
            ProposerPriority = proposerPriority;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        [JsonConverter(typeof(Base64StringByteArrayConverter))]
        public byte[] Address { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pub_key")]
        public string PubKey { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voting_power")]
        public long VotingPower { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer_priority")]
        public long ProposerPriority { get; set; }

    }
}
