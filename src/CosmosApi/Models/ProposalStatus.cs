using System.Runtime.Serialization;

namespace CosmosApi.Models
{
    /// <summary>
    /// ProposalStatus is a type alias that represents a proposal status as a byte.
    /// </summary>
    public enum ProposalStatus : byte
    {
        [EnumMember(Value = "")]
        Nil = 0,
        
        [EnumMember(Value = "DepositPeriod")]
        DepositPeriod = 1,

        [EnumMember(Value = "VotingPeriod")] 
        VotingPeriod = 2,

        [EnumMember(Value = "Passed")]
        Passed = 3,

        [EnumMember(Value = "Rejected")]
        Rejected = 4,

        [EnumMember(Value = "Failed")] 
        Failed = 5,
    }
}