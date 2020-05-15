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

        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostWithdrawRewardsSimulation(WithdrawRewardsRequest request);
 
        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostWithdrawRewardsAsync(WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostWithdrawRewards(WithdrawRewardsRequest request);
    }
}