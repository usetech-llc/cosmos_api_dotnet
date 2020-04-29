using System.Runtime.Serialization;

namespace CosmosApi.Models
{
    /// <summary>
    /// Vote options.
    /// </summary>
    public enum VoteOption : byte
    {
        /// <summary>
        /// Note: there is actually no way to serialize Empty.
        /// </summary>
        [EnumMember(Value = "")]
        Empty = 0x00,
        [EnumMember(Value = "Yes")]
        Yes = 0x01,
        [EnumMember(Value = "Abstain")]
        Abstain = 0x02,
        [EnumMember(Value = "No")]
        No = 0x03,
        [EnumMember(Value = "NoWithVeto")]
        NoWithVeto = 0x04,
    }
}