using System.Net.Http;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class BlockID
    {
        /// <summary>
        /// Initializes a new instance of the BlockID class.
        /// </summary>
        public BlockID()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BlockID class.
        /// </summary>
        public BlockID(byte[] hash = default(byte[]), BlockIDParts parts = default(BlockIDParts))
        {
            Hash = hash;
            Parts = parts;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] Hash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parts")]
        public BlockIDParts Parts { get; set; }

    }
}
