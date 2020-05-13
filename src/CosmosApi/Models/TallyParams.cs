using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Param around Tallying votes in governance.
    /// </summary>
    public class TallyParams
    {
        /// <summary>
        /// Minimum percentage of total stake needed to vote for a result to be considered valid.
        /// </summary>
        [JsonProperty("quorum")]
        public BigDecimal? Quorum { get; set; }
        
        /// <summary>
        /// Minimum proportion of Yes votes for proposal to pass.
        /// </summary>
        [JsonProperty("threshold")]
        public BigDecimal? Threshold { get; set; }
        
        /// <summary>
        /// Minimum value of Veto votes to Total votes ratio for proposal to be vetoed.
        /// </summary>
        [JsonProperty("veto")]
        public BigDecimal? Veto { get; set; }

        public TallyParams()
        {
        }

        public TallyParams(BigDecimal? quorum, BigDecimal? threshold, BigDecimal? veto)
        {
            Quorum = quorum;
            Threshold = threshold;
            Veto = veto;
        }
    }
}