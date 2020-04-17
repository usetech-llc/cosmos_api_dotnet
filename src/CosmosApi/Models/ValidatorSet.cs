using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ValidatorSet
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ValidatorSet
        /// class.
        /// </summary>
        public ValidatorSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ValidatorSet
        /// class.
        /// </summary>
        public ValidatorSet(long blockHeight, IList<TendermintValidator> validators)
        {
            BlockHeight = blockHeight;
            Validators = validators;
        }


        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_height")]
        public long BlockHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validators")]
        public IList<TendermintValidator> Validators { get; set; } = null!;
    }
}
