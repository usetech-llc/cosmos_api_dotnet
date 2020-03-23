using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class TallyResult
    {
        /// <summary>
        /// Initializes a new instance of the TallyResult class.
        /// </summary>
        public TallyResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TallyResult class.
        /// </summary>
        public TallyResult(string yes = default(string), string abstain = default(string), string no = default(string), string noWithVeto = default(string))
        {
            Yes = yes;
            Abstain = abstain;
            No = no;
            NoWithVeto = noWithVeto;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "yes")]
        public string Yes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "abstain")]
        public string Abstain { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no")]
        public string No { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "no_with_veto")]
        public string NoWithVeto { get; set; }

    }
}
