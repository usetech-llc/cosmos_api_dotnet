using System.Collections.Generic;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Newtonsoft.Json;

namespace NameserviceApi.Models
{
    public class Account : IAccount
    {
        [JsonProperty("address")]
        public string Address { get; set; } = null!;
        [JsonProperty("coins")]
        public IList<Coin> Coins { get; set; } = null!;
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = null!;
        [JsonProperty("account_number")]
        public ulong AccountNumber { get; set; }
        [JsonProperty("sequence")]
        public ulong Sequence { get; set; }

        public Account()
        {
        }

        public Account(string address, IList<Coin> coins, string publicKey, ulong accountNumber, ulong sequence)
        {
            Address = address;
            Coins = coins;
            PublicKey = publicKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
        }

        public PublicKey GetPublicKey()
        {
            return new PublicKey()
            {
                Type = null,
                Value = PublicKey
            };
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