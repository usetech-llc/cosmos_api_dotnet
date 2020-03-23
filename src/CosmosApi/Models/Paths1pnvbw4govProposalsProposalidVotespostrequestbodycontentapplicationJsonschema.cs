using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1pnvbw4govProposalsProposalidVotespostrequestbodycontentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1pnvbw4govProposalsProposalidVotespostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1pnvbw4govProposalsProposalidVotespostrequestbodycontentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1pnvbw4govProposalsProposalidVotespostrequestbodycontentapplicationJsonschema
        /// class.
        /// </summary>
        public Paths1pnvbw4govProposalsProposalidVotespostrequestbodycontentapplicationJsonschema(BaseReq baseReq = default(BaseReq), string voter = default(string), string option = default(string))
        {
            BaseReq = baseReq;
            Voter = voter;
            Option = option;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "base_req")]
        public BaseReq BaseReq { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voter")]
        public string Voter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "option")]
        public string Option { get; set; }

    }
}
