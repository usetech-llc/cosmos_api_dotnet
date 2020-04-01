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
        public byte[] AccAddress { get; set; }
        
        [JsonProperty("coins")]
        public IList<Coin> Coins { get; set; }

        public Input()
        {
        }

        public Input(byte[] accAddress, IList<Coin> coins)
        {
            AccAddress = accAddress;
            Coins = coins;
        }
    }
}