using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue
        /// class.
        /// </summary>
        public Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue
        /// class.
        /// </summary>
        public Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue(string accountNumber = default(string), string address = default(string), IList<Coin> coins = default(IList<Coin>), PublicKey publicKey = default(PublicKey), string sequence = default(string))
        {
            AccountNumber = accountNumber;
            Address = address;
            Coins = coins;
            PublicKey = publicKey;
            Sequence = sequence;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "coins")]
        public IList<Coin> Coins { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "public_key")]
        public PublicKey PublicKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public string Sequence { get; set; }

    }
}
