using CosmosApi.Models;
using Newtonsoft.Json;

namespace NameserviceApi.Models
{
    public class BuyNameReq
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("amount")]
        public string Amount { get; set; } = null!;
        [JsonProperty("buyer")]
        public string Buyer { get; set; } = null!;

        public BuyNameReq()
        {
        }

        public BuyNameReq(BaseReq baseReq, string name, string amount, string buyer)
        {
            BaseReq = baseReq;
            Name = name;
            Amount = amount;
            Buyer = buyer;
        }
    }
}