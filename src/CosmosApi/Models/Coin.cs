using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public partial class Coin
    {
        /// <summary>
        /// Initializes a new instance of the Coin class.
        /// </summary>
        public Coin()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Coin class.
        /// </summary>
        public Coin(string denom = default(string), string amount = default(string))
        {
            Denom = denom;
            Amount = amount;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "denom")]
        public string Denom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

    }
}
