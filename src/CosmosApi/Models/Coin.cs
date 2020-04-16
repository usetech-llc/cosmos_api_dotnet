using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// Coin hold some amount of one currency.
    /// CONTRACT: A coin will never hold a negative amount of any denomination.
    /// </summary>

    public class Coin
    {
        /// <summary>
        /// Initializes a new instance of the Coin class.
        /// </summary>
        public Coin()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Coin class.
        /// </summary>
        public Coin(string denom = default, int amount = default)
        {
            Denom = denom;
            Amount = amount;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "denom")]
        public string Denom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        [JsonConverter(typeof(StringNumberConverter))]
        public long Amount { get; set; }

    }
}
