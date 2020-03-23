using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public partial class TendermintValidator
    {
        /// <summary>
        /// Initializes a new instance of the TendermintValidator class.
        /// </summary>
        public TendermintValidator()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TendermintValidator class.
        /// </summary>
        public TendermintValidator(string address = default(string), string pubKey = default(string), string votingPower = default(string), string proposerPriority = default(string))
        {
            Address = address;
            PubKey = pubKey;
            VotingPower = votingPower;
            ProposerPriority = proposerPriority;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pub_key")]
        public string PubKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voting_power")]
        public string VotingPower { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposer_priority")]
        public string ProposerPriority { get; set; }

    }
}
