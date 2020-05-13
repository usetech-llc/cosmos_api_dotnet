using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TallyResult
    {
        /// <summary>
        /// Initializes a new instance of the TallyResult class.
        /// </summary>
        public TallyResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TallyResult class.
        /// </summary>
        public TallyResult(BigDecimal yes, BigDecimal abstain, BigDecimal no, BigDecimal noWithVeto)
        {
            Yes = yes;
            Abstain = abstain;
            No = no;
            NoWithVeto = noWithVeto;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "yes")]
        public BigDecimal Yes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abstain")]
        public BigDecimal Abstain { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no")]
        public BigDecimal No { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no_with_veto")]
        public BigDecimal NoWithVeto { get; set; }

    }
}
