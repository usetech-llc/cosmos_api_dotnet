using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// Fee distribution module APIs.
    /// </summary>
    public interface IDistribution
    {
        /// <summary>
        /// Get the total rewards balance from all delegations.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<DelegatorTotalRewards>> GetDelegatorRewardsAsync(string delegatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get the total rewards balance from all delegations.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<DelegatorTotalRewards> GetDelegatorRewards(string delegatorAddress);
    }
}