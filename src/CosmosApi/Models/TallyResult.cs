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
        public TallyResult(string yes, string abstain, string no, string noWithVeto)
        {
            Yes = yes;
            Abstain = abstain;
            No = no;
            NoWithVeto = noWithVeto;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "yes")]
        public string Yes { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abstain")]
        public string Abstain { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no")]
        public string No { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no_with_veto")]
        public string NoWithVeto { get; set; } = null!;

    }
}
