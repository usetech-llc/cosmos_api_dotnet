using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BaseAccount : IAccount
    {
        /// <summary>
        /// Initializes a new instance of the
        /// BaseAccount
        /// class.
        /// </summary>
        public BaseAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// BaseAccount
        /// class.
        /// </summary>
        public BaseAccount(ulong accountNumber = default, string address = default, IList<Coin> coins = default, PublicKey publicKey = default, ulong sequence = default)
        {
            AccountNumber = accountNumber;
            Address = address;
            Coins = coins;
            PublicKey = publicKey;
            Sequence = sequence;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public ulong AccountNumber { get; set; }

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
        public ulong Sequence { get; set; }

    }
}
