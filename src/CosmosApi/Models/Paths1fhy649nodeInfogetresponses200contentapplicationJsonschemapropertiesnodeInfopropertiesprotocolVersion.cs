using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1fhy649nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfopropertiesprotocolVersion
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1fhy649nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfopropertiesprotocolVersion
        /// class.
        /// </summary>
        public Paths1fhy649nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfopropertiesprotocolVersion()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1fhy649nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfopropertiesprotocolVersion
        /// class.
        /// </summary>
        public Paths1fhy649nodeInfogetresponses200contentapplicationJsonschemapropertiesnodeInfopropertiesprotocolVersion(string p2p = default(string), string block = default(string), string app = default(string))
        {
            P2p = p2p;
            Block = block;
            App = app;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "p2p")]
        public string P2p { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public string Block { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "app")]
        public string App { get; set; }

    }
}
