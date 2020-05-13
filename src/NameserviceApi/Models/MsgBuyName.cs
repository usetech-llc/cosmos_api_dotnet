using System.Collections.Generic;
using CosmosApi.Models;
using Newtonsoft.Json;

namespace NameserviceApi.Models
{
    public class MsgBuyName : IMsg
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("bid")]
        public IList<Coin> Bid { get; set; } = null!;
        [JsonProperty("buyer")]
        public string Buyer { get; set; } = null!;

        public MsgBuyName()
        {
        }

        public MsgBuyName(string name, IList<Coin> bid, string buyer)
        {
            Name = name;
            Bid = bid;
            Buyer = buyer;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}