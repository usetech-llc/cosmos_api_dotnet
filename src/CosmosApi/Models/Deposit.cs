using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Deposit
    {
        /// <summary>
        /// Initializes a new instance of the Deposit class.
        /// </summary>
        public Deposit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Deposit class.
        /// </summary>
        public Deposit(IList<Coin> amount, ulong proposalId, string depositor)
        {
            Amount = amount;
            ProposalId = proposalId;
            Depositor = depositor;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "depositor")]
        public string Depositor { get; set; } = null!;

    }
}
