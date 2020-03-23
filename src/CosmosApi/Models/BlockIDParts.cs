using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockIDParts
    {
        /// <summary>
        /// Initializes a new instance of the BlockIDParts class.
        /// </summary>
        public BlockIDParts()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockIDParts class.
        /// </summary>
        public BlockIDParts(double? total = default(double?), string hash = default(string))
        {
            Total = total;
            Hash = hash;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public double? Total { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

    }
}
