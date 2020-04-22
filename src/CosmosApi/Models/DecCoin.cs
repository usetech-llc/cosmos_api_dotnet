using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// DecCoin defines a coin which can have additional decimal points.
    /// </summary>
    public class DecCoin
    {
        [JsonProperty("denom")] 
        public string Denom { get; set; } = null!;
        
        [JsonProperty("amount")]
        public BigDecimal Amount { get; set; }

        public DecCoin()
        {
        }

        public DecCoin(string denom, BigDecimal amount)
        {
            Denom = denom;
            Amount = amount;
        }
    }
}