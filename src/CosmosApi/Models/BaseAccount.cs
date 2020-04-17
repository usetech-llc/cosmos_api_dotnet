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
        public BaseAccount(ulong accountNumber, string address, IList<Coin> coins, PublicKey publicKey, ulong sequence)
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
        public string Address { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "coins")]
        public IList<Coin> Coins { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "public_key")]
        public PublicKey PublicKey { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public ulong Sequence { get; set; }

        public PublicKey GetPublicKey()
        {
            return PublicKey;
        }

        public ulong GetSequence()
        {
            return Sequence;
        }

        public ulong GetAccountNumber()
        {
            return AccountNumber;
        }
    }
}
