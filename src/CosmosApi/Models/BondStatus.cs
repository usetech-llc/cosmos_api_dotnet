using System.Runtime.Serialization;

namespace CosmosApi.Models
{
    public enum BondStatus
    {
        [EnumMember(Value = "Unbonded")]
        Unbonded = 0,
        [EnumMember(Value = "Unbonding")]
        Unbonding = 1,
        [EnumMember(Value = "Bonded")]
        Bonded = 2,
    }
}