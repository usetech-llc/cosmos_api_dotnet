using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1nnrngslashingParametersgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1nnrngslashingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1nnrngslashingParametersgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1nnrngslashingParametersgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1nnrngslashingParametersgetresponses200contentapplicationJsonschema(string maxEvidenceAge = default(string), string signedBlocksWindow = default(string), string minSignedPerWindow = default(string), string doubleSignUnbondDuration = default(string), string downtimeUnbondDuration = default(string), string slashFractionDoubleSign = default(string), string slashFractionDowntime = default(string))
        {
            MaxEvidenceAge = maxEvidenceAge;
            SignedBlocksWindow = signedBlocksWindow;
            MinSignedPerWindow = minSignedPerWindow;
            DoubleSignUnbondDuration = doubleSignUnbondDuration;
            DowntimeUnbondDuration = downtimeUnbondDuration;
            SlashFractionDoubleSign = slashFractionDoubleSign;
            SlashFractionDowntime = slashFractionDowntime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "max_evidence_age")]
        public string MaxEvidenceAge { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "signed_blocks_window")]
        public string SignedBlocksWindow { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "min_signed_per_window")]
        public string MinSignedPerWindow { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "double_sign_unbond_duration")]
        public string DoubleSignUnbondDuration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "downtime_unbond_duration")]
        public string DowntimeUnbondDuration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "slash_fraction_double_sign")]
        public string SlashFractionDoubleSign { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "slash_fraction_downtime")]
        public string SlashFractionDowntime { get; set; }

    }
}
