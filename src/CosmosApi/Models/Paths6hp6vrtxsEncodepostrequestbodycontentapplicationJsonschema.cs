using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths6hp6vrtxsEncodepostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths6hp6vrtxsEncodepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths6hp6vrtxsEncodepostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths6hp6vrtxsEncodepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths6hp6vrtxsEncodepostrequestbodycontentapplicationJsonschema(StdTx tx = default(StdTx))
        {
            Tx = tx;
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

    }
}
