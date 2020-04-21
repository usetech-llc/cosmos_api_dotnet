using System.Numerics;
using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Delegation
    {
        /// <summary>
        /// Initializes a new instance of the Delegation class.
        /// </summary>
        public Delegation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Delegation class.
        /// </summary>
        public Delegation(string delegatorAddress, string validatorAddress, BigDecimal shares, BigInteger balance)
        {
            DelegatorAddress = delegatorAddress;
            ValidatorAddress = validatorAddress;
            Shares = shares;
            Balance = balance;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delegator_address")]
        public string DelegatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validator_address")]
        public string ValidatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shares")]
        public BigDecimal Shares { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public BigInteger Balance { get; set; }

    }
}
