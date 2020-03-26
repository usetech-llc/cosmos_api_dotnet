using CosmosApi.Serialization;
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
        public BlockIDParts(int? total = default(int?), byte[] hash = default(byte[]))
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
        public int? Total { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] Hash { get; set; }
    }
}
