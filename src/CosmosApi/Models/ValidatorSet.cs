using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ValidatorSet
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ValidatorSet
        /// class.
        /// </summary>
        public ValidatorSet()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ValidatorSet
        /// class.
        /// </summary>
        public ValidatorSet(string blockHeight = default(string), IList<TendermintValidator> validators = default(IList<TendermintValidator>))
        {
            BlockHeight = blockHeight;
            Validators = validators;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "block_height")]
        public string BlockHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validators")]
        public IList<TendermintValidator> Validators { get; set; }

    }
}
