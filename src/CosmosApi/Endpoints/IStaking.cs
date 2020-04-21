using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// Stake module APIs.
    /// </summary>
    public interface IStaking
    {
        /// <summary>
        /// Get all delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr);
    }
}