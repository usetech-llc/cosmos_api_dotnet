using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Param around Voting in governance.
    /// </summary>
    public class VotingParams
    {
        /// <summary>
        /// Length of the voting period in nanoseconds.
        /// </summary>
        [JsonProperty("voting_period")]
        public long? VotingPeriod { get; set; }

        public VotingParams()
        {
        }

        public VotingParams(long? votingPeriod)
        {
            VotingPeriod = votingPeriod;
        }
    }
}