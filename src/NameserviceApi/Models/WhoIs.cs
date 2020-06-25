using System.Collections.Generic;
using CosmosApi.Models;
using Newtonsoft.Json;

namespace NameserviceApi.Models
{
    public class WhoIs
    {
        [JsonProperty("value")]
        public string Value { get; set; } = null!;
        [JsonProperty("owner")]
        public string Owner { get; set; } = null!;
        [JsonProperty("price")]
        public IList<Coin> Price { get; set; } = null!;
    }
}