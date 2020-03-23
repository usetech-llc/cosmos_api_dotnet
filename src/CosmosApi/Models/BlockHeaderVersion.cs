using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockHeaderVersion
    {
        /// <summary>
        /// Initializes a new instance of the BlockHeaderVersion class.
        /// </summary>
        public BlockHeaderVersion()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockHeaderVersion class.
        /// </summary>
        public BlockHeaderVersion(string block = default(string), string app = default(string))
        {
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
        [JsonProperty(PropertyName = "block")]
        public string Block { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "app")]
        public string App { get; set; }

    }
}
