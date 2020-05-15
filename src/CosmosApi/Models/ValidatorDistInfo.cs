using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class ValidatorDistInfo
    {
        /// <summary>
        /// Initializes a new instance of the ValidatorDistInfo class.
        /// </summary>
        public ValidatorDistInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ValidatorDistInfo class.
        /// </summary>
        public ValidatorDistInfo(string operatorAddress, IList<DecCoin> selfBondRewards, IList<DecCoin> valCommission)
        {
            OperatorAddress = operatorAddress;
            SelfBondRewards = selfBondRewards;
            ValCommission = valCommission;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "operator_address")]
        public string OperatorAddress { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "self_bond_rewards")]
        public IList<DecCoin> SelfBondRewards { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "val_commission")]
        public IList<DecCoin> ValCommission { get; set; } = null!;

    }
}
