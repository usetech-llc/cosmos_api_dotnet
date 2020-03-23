using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1dplpzctxsDecodepostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1dplpzctxsDecodepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1dplpzctxsDecodepostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1dplpzctxsDecodepostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1dplpzctxsDecodepostrequestbodycontentapplicationJsonschema(string tx = default(string))
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
        public string Tx { get; set; }

    }
}
