using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths14mn4yvsyncinggetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths14mn4yvsyncinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths14mn4yvsyncinggetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths14mn4yvsyncinggetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths14mn4yvsyncinggetresponses200contentapplicationJsonschema(bool? syncing = default(bool?))
        {
            Syncing = syncing;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "syncing")]
        public bool? Syncing { get; set; }

    }
}
