using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// DepositReq defines the properties of a deposit request's body.
    /// </summary>
    public class DepositReq
    {
        [JsonProperty("base_req")]
        public BaseReq BaseReq { get; set; } = null!;
        
        /// <summary>
        /// Address of the depositor.
        /// </summary>
        [JsonProperty("depositor")]
        public string Depositor { get; set; } = null!;

        /// <summary>
        /// Coins to add to the proposal's deposit.
        /// </summary>
        [JsonProperty("amount")]
        public IList<Coin> Amount { get; set; } = null!;

        public DepositReq()
        {
        }

        public DepositReq(BaseReq baseReq, string depositor, IList<Coin> amount)
        {
            BaseReq = baseReq;
            Depositor = depositor;
            Amount = amount;
        }
    }
}