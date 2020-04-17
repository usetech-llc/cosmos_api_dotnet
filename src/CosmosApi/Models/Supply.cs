using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Supply
    {
        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public Supply()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public Supply(IList<Coin> total)
        {
            Total = total;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public IList<Coin> Total { get; set; } = null!;

    }
}
