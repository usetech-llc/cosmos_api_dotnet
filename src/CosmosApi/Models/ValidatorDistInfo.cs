using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class ValidatorDistInfo
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorDistInfo class.
        /// </summary>
        public ValidatorDistInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorDistInfo class.
        /// </summary>
        public ValidatorDistInfo(string operatorAddress = default(string), IList<Coin> selfBondRewards = default(IList<Coin>), IList<Coin> valCommission = default(IList<Coin>))
        {
            OperatorAddress = operatorAddress;
            SelfBondRewards = selfBondRewards;
            ValCommission = valCommission;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "operator_address")]
        public string OperatorAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "self_bond_rewards")]
        public IList<Coin> SelfBondRewards { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "val_commission")]
        public IList<Coin> ValCommission { get; set; }

    }
}
