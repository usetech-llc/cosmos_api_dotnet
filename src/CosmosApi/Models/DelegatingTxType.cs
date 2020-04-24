using System.Runtime.Serialization;

namespace CosmosApi.Models
{
    public enum DelegatingTxType
    {
        [EnumMember(Value = "bond")]
        Bond = 1,
        [EnumMember(Value = "unbond")]
        Unbond = 2,
        [EnumMember(Value = "redelegate")]
        Redelegate = 3,
        
    }
}