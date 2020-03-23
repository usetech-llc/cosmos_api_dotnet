using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1m3ojbslashingValidatorsValidatoraddrUnjailpostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1m3ojbslashingValidatorsValidatoraddrUnjailpostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1m3ojbslashingValidatorsValidatoraddrUnjailpostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1m3ojbslashingValidatorsValidatoraddrUnjailpostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1m3ojbslashingValidatorsValidatoraddrUnjailpostrequestbodycontentapplicationJsonschema(StdTx baseReq = default(StdTx))
        {
            BaseReq = baseReq;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "base_req")]
        public StdTx BaseReq { get; set; }

    }
}
