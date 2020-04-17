using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Input models transaction input.
    /// </summary>
    public class Input
    {
        [JsonProperty("address")]
        public string AccAddress { get; set; } = null!;
        
        [JsonProperty("coins")]
        public IList<Coin> Coins { get; set; } = null!;

        public Input()
        {
        }

        public Input(string accAddress, IList<Coin> coins)
        {
            AccAddress = accAddress;
            Coins = coins;
        }
    }
}