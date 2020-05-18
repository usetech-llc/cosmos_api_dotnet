using System.Collections.Generic;
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
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string delegatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostWithdrawRewardsSimulation(string delegatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostWithdrawRewardsAsync(string delegatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Post a simulation for a withdraw all delegator rewards request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostWithdrawRewards(string delegatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Query a delegation reward.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<DecCoin>>> GetDelegatorRewardsAsync(string delegatorAddress, string validatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Query a delegation reward.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<DecCoin>> GetDelegatorRewards(string delegatorAddress, string validatorAddress);

        /// <summary>
        /// Post a sumilation of withdraw a delegator's delegation reward from a single validator request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Post a sumilation of withdraw a delegator's delegation reward from a single validator request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostWithdrawRewardsSimulation(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Withdraw a delegator's delegation reward from a single validator.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostWithdrawRewardsAsync(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Withdraw a delegator's delegation reward from a single validator.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostWithdrawRewards(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Get the delegations' rewards withdrawal address. This is the address in which the user will receive the reward funds.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<string>> GetWithdrawAddressAsync(string delegatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get the delegations' rewards withdrawal address. This is the address in which the user will receive the reward funds.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<string> GetWithdrawAddress(string delegatorAddress);

        /// <summary>
        /// Post a simulation of a replace the delegations' rewards withdrawal address for a new one request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostWithdrawAddressSimulationAsync(string delegatorAddress, SetWithdrawalAddrRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Post a simulation of a replace the delegations' rewards withdrawal address for a new one request.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostWithdrawAddressSimulation(string delegatorAddress, SetWithdrawalAddrRequest request);

        /// <summary>
        /// Replace the delegations' rewards withdrawal address for a new one.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostWithdrawAddressAsync(string delegatorAddress, SetWithdrawalAddrRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Replace the delegations' rewards withdrawal address for a new one.
        /// </summary>
        /// <param name="delegatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostWithdrawAddress(string delegatorAddress, SetWithdrawalAddrRequest request);

        /// <summary>
        /// Query the distribution information of a single validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<ValidatorDistInfo>> GetValidatorDistributionInfoAsync(string validatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Query the distribution information of a single validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<ValidatorDistInfo> GetValidatorDistributionInfo(string validatorAddress);

        /// <summary>
        /// Fee distribution outstanding rewards of a single validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorOutstandingRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Fee distribution outstanding rewards of a single validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<DecCoin>> GetValidatorOutstandingRewards(string validatorAddress);

        /// <summary>
        /// Query the commission and self-delegation rewards of validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default);
        /// <summary>
        /// Query the commission and self-delegation rewards of validator.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<DecCoin>> GetValidatorRewards(string validatorAddress);

        /// <summary>
        /// Post a sumulation of a withdraw the validator's self-delegation and commissions rewards request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostValidatorWithdrawRewardsSimulationAsync(string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Post a sumulation of a withdraw the validator's self-delegation and commissions rewards request.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostValidatorWithdrawRewardsSimulation(string validatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Withdraw the validator's self-delegation and commissions rewards.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StdTx> PostValidatorWithdrawRewardsAsync(string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Withdraw the validator's self-delegation and commissions rewards.
        /// </summary>
        /// <param name="validatorAddress"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        StdTx PostValidatorWithdrawRewards(string validatorAddress, WithdrawRewardsRequest request);

        /// <summary>
        /// Community pool parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<DecCoin>>> GetCommunityPoolAsync(long? height = default, CancellationToken cancellationToken = default);
        /// <summary>
        /// Community pool parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        ResponseWithHeight<IList<DecCoin>> GetCommunityPool(long? height = default);

        /// <summary>
        /// Fee distribution parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<DistributionParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default);
        /// <summary>
        /// Fee distribution parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        ResponseWithHeight<DistributionParams> GetParams(long? height = default);
    }
}