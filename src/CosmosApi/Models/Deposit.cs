using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Deposit
    {
        /// <summary>
        /// Initializes a new instance of the Deposit class.
        /// </summary>
        public Deposit()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Deposit class.
        /// </summary>
        public Deposit(IList<Coin> amount = default(IList<Coin>), string proposalId = default(string), string depositor = default(string))
        {
            Amount = amount;
            ProposalId = proposalId;
            Depositor = depositor;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public IList<Coin> Amount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "proposal_id")]
        public string ProposalId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "depositor")]
        public string Depositor { get; set; }

    }
}
