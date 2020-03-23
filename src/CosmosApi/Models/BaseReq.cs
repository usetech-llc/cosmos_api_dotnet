using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public partial class BaseReq
    {
        /// <summary>
        /// Initializes a new instance of the BaseReq class.
        /// </summary>
        public BaseReq()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BaseReq class.
        /// </summary>
        /// <param name="fromProperty">Sender address or Keybase name to
        /// generate a transaction</param>
        /// <param name="simulate">Estimate gas for a transaction (cannot be
        /// used in conjunction with generate_only)</param>
        public BaseReq(string fromProperty = default(string), string memo = default(string), string chainId = default(string), string accountNumber = default(string), string sequence = default(string), string gas = default(string), string gasAdjustment = default(string), IList<Coin> fees = default(IList<Coin>), bool? simulate = default(bool?))
        {
            FromProperty = fromProperty;
            Memo = memo;
            ChainId = chainId;
            AccountNumber = accountNumber;
            Sequence = sequence;
            Gas = gas;
            GasAdjustment = gasAdjustment;
            Fees = fees;
            Simulate = simulate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets sender address or Keybase name to generate a
        /// transaction
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public string FromProperty { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memo")]
        public string Memo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chain_id")]
        public string ChainId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public string Sequence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas")]
        public string Gas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gas_adjustment")]
        public string GasAdjustment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fees")]
        public IList<Coin> Fees { get; set; }

        /// <summary>
        /// Gets or sets estimate gas for a transaction (cannot be used in
        /// conjunction with generate_only)
        /// </summary>
        [JsonProperty(PropertyName = "simulate")]
        public bool? Simulate { get; set; }

    }
}
