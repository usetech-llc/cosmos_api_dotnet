using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Delegation
    {
        /// <summary>
        /// Initializes a new instance of the Delegation class.
        /// </summary>
        public Delegation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Delegation class.
        /// </summary>
        public Delegation(string delegatorAddress = default(string), string validatorAddress = default(string), string shares = default(string), Coin balance = default(Coin))
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Shares = shares;
            Balance = balance;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shares")]
        public string Shares { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public Coin Balance { get; set; }

    }
}
