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
    }
}