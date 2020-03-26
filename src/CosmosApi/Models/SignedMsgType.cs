namespace CosmosApi.Models
{
    public enum SignedMsgType : byte
    {
        // Votes
        PrevoteType = 0x01,
        PrecommitType = 0x02,

        // Proposals
        ProposalType = 0x20
    }
}