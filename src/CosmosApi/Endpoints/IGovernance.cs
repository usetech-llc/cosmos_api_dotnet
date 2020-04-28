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
    }
}