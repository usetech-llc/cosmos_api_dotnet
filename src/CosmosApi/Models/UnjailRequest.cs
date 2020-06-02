using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Unjail TX body.
    /// </summary>
    public class UnjailRequest
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        
        public UnjailRequest()
        {
        }

        public UnjailRequest(BaseReq baseReq)
        {
            BaseReq = baseReq;
        }
    }
}