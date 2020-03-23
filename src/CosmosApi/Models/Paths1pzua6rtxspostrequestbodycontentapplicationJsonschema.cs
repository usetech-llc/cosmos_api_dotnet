using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1pzua6rtxspostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1pzua6rtxspostrequestbodycontentapplicationJsonschema class.
        /// </summary>
        public Paths1pzua6rtxspostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1pzua6rtxspostrequestbodycontentapplicationJsonschema class.
        /// </summary>
        public Paths1pzua6rtxspostrequestbodycontentapplicationJsonschema(StdTx tx = default(StdTx), string mode = default(string))
        {
            Tx = tx;
            Mode = mode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx")]
        public StdTx Tx { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public string Mode { get; set; }

    }
}
