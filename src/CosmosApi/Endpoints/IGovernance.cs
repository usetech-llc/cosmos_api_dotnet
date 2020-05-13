using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// Governance module APIs.
    /// </summary>
    public interface IGovernance
    {
        /// <summary>
        /// Query proposals.
        /// </summary>
        /// <param name="voter">Voter address.</param>
        /// <param name="depositor">Depositor address.</param>
        /// <param name="status">Proposal status.</param>
        /// <param name="limit">Maximum number of items.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Proposal>>> GetProposalsAsync(string? voter = default, string? depositor = default, ProposalStatus? status = default, ulong? limit = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query proposals.
        /// </summary>
        /// <param name="voter">Voter address.</param>
        /// <param name="depositor">Depositor address.</param>
        /// <param name="status">Proposal status.</param>
        /// <param name="limit">Maximum number of items.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Proposal>> GetProposals(string? voter = default, string? depositor = default, ProposalStatus? status = default, ulong? limit = default);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostProposalSimulationAsync(PostProposalReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        Task<GasEstimateResponse> PostProposalSimulationAsync(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        Task<GasEstimateResponse> PostProposalSimulationAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent;
 
        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        GasEstimateResponse PostProposalSimulation(PostProposalReq request);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        GasEstimateResponse PostProposalSimulation(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        GasEstimateResponse PostProposalSimulation<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit) where TContentType : IProposalContent;
        
        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostProposalAsync(PostProposalReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        Task<StdTx> PostProposalAsync(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        Task<StdTx> PostProposalAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent;
 
        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        StdTx PostProposal(PostProposalReq request);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        StdTx PostProposal(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit, Type proposalContentType);

        /// <summary>
        /// Submit a proposal.
        /// </summary>
        /// <returns></returns>
        StdTx PostProposal<TContentType>(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit) where TContentType : IProposalContent;

        /// <summary>
        /// Query a proposal.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<Proposal>> GetProposalAsync(ulong id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query a proposal.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseWithHeight<Proposal> GetProposal(ulong id);

        /// <summary>
        /// Query proposer.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<Proposer>> GetProposerByProposalIdAsync(ulong proposalId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query proposer.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
        ResponseWithHeight<Proposer> GetProposerByProposalId(ulong proposalId);

        /// <summary>
        /// Query deposits.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Deposit>>> GetDepositsAsync(ulong proposalId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query deposits.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<Deposit>> GetDeposits(ulong proposalId);

        /// <summary>
        /// Deposit tokens to a proposal.
        /// Send transaction to deposit tokens to a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostDepositSimulationAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deposit tokens to a proposal.
        /// Send transaction to deposit tokens to a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostDepositSimulation(ulong proposalId, DepositReq request);

        /// <summary>
        /// Deposit tokens to a proposal.
        /// Send transaction to deposit tokens to a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostDepositAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deposit tokens to a proposal.
        /// Send transaction to deposit tokens to a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostDeposit(ulong proposalId, DepositReq request);

        /// <summary>
        /// Query deposits.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="depositor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<Deposit>> GetDepositAsync(ulong proposalId, string depositor, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query deposits.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="depositor"></param>
        /// <returns></returns>
        ResponseWithHeight<Deposit> GetDeposit(ulong proposalId, string depositor);

        /// <summary>
        /// Query voters information by proposalId.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Vote>>> GetVotesAsync(ulong proposalId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query voters information by proposalId.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<Vote>> GetVotes(ulong proposalId);

        /// <summary>
        /// Send transaction to vote a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostVoteSimulationAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send transaction to vote a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostVoteSimulation(ulong proposalId, VoteReq request);

        /// <summary>
        /// Send transaction to vote a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostVoteAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send transaction to vote a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostVote(ulong proposalId, VoteReq request);

        /// <summary>
        /// Query vote information by proposal Id and voter address.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="voter">Bech32 voter address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<Vote>> GetVoteAsync(ulong proposalId, string voter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query vote information by proposal Id and voter address.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="voter">Bech32 voter address.</param>
        /// <returns></returns>
        ResponseWithHeight<Vote> GetVote(ulong proposalId, string voter);

        /// <summary>
        /// Gets a proposal’s tally result at the current time. If the proposal is pending deposits (i.e status ‘DepositPeriod’) it returns an empty tally result.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<TallyResult>> GetTallyAsync(ulong proposalId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a proposal’s tally result at the current time. If the proposal is pending deposits (i.e status ‘DepositPeriod’) it returns an empty tally result.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
        ResponseWithHeight<TallyResult> GetTally(ulong proposalId);

        /// <summary>
        /// Query governance deposit parameters.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<DepositParams>> GetDepositParamsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Query governance deposit parameters.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<DepositParams> GetDepositParams();

        /// <summary>
        /// Query governance tally parameters.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<TallyParams>> GetTallyParamsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Query governance tally parameters.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<TallyParams> GetTallyParams();

        /// <summary>
        /// Query governance voting parameters.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<VotingParams>> GetVotingParamsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Query governance voting parameters.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<VotingParams> GetVotingParams();
    }
}