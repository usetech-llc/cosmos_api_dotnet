using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class StdTxFee
    {
        /// <summary>
        /// Initializes a new instance of the StdTxFee class.
        /// </summary>
        public StdTxFee()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StdTxFee class.
        /// </summary>
        public StdTxFee(string gas = default(string), IList<Coin> amount = default(IList<Coin>))
        {
            Gas = gas;
            Amount = amount;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas")]
        public string Gas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; }

    }
}
