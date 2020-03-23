using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Supply
    {
        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public Supply()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public Supply(IList<Coin> total = default(IList<Coin>))
        {
            Total = total;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public IList<Coin> Total { get; set; }

    }
}
