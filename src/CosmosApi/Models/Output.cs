using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Output models transaction outputs.
    /// </summary>
    public class Output
    {
        [JsonProperty("address")]
        public string AccAddress { get; set; }
        
        [JsonProperty("coins")]
        public IList<Coin> Coins { get; set; }

        public Output()
        {
        }

        public Output(string accAddress, IList<Coin> coins)
        {
            AccAddress = accAddress;
            Coins = coins;
        }
    }
}