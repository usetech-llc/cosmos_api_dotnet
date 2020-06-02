using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    public class Distribution : IDistribution
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Distribution(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<DelegatorTotalRewards>> GetDelegatorRewardsAsync(string delegatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards")
                .GetJsonAsync<ResponseWithHeight<DelegatorTotalRewards>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<DelegatorTotalRewards> GetDelegatorRewards(string delegatorAddress)
        {
            return GetDelegatorRewardsAsync(delegatorAddress)
                .Sync();
        }

        public Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string delegatorAddress, WithdrawRewardsRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostWithdrawRewardsSimulation(string delegatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsSimulationAsync(delegatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostWithdrawRewardsAsync(string delegatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostWithdrawRewards(string delegatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsAsync(delegatorAddress, request)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<DecCoin>>> GetDelegatorRewardsAsync(string delegatorAddress, string validatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards", validatorAddress)
                .GetJsonAsync<ResponseWithHeight<IList<DecCoin>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<DecCoin>> GetDelegatorRewards(string delegatorAddress, string validatorAddress)
        {
            return GetDelegatorRewardsAsync(delegatorAddress, validatorAddress)
                .Sync();
        }

        public Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards", validatorAddress)
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostWithdrawRewardsSimulation(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsSimulationAsync(delegatorAddress, validatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostWithdrawRewardsAsync(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "rewards", validatorAddress)
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostWithdrawRewards(string delegatorAddress, string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsAsync(delegatorAddress, validatorAddress, request)
                .Sync();
        }

        public Task<ResponseWithHeight<string>> GetWithdrawAddressAsync(string delegatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "withdraw_address")
                .GetJsonAsync<ResponseWithHeight<string>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<string> GetWithdrawAddress(string delegatorAddress)
        {
            return GetWithdrawAddressAsync(delegatorAddress)
                .Sync();
        }

        public Task<GasEstimateResponse> PostWithdrawAddressSimulationAsync(string delegatorAddress, SetWithdrawalAddrRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new SetWithdrawalAddrRequest(baseReq, request.WithdrawAddress);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "withdraw_address")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostWithdrawAddressSimulation(string delegatorAddress, SetWithdrawalAddrRequest request)
        {
            return PostWithdrawAddressSimulationAsync(delegatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostWithdrawAddressAsync(string delegatorAddress, SetWithdrawalAddrRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new SetWithdrawalAddrRequest(baseReq, request.WithdrawAddress);

            return _clientGetter()
                .Request("distribution", "delegators", delegatorAddress, "withdraw_address")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostWithdrawAddress(string delegatorAddress, SetWithdrawalAddrRequest request)
        {
            return PostWithdrawAddressAsync(delegatorAddress, request)
                .Sync();
        }

        public Task<ResponseWithHeight<ValidatorDistInfo>> GetValidatorDistributionInfoAsync(string validatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "validators", validatorAddress)
                .GetJsonAsync<ResponseWithHeight<ValidatorDistInfo>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<ValidatorDistInfo> GetValidatorDistributionInfo(string validatorAddress)
        {
            return GetValidatorDistributionInfoAsync(validatorAddress)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorOutstandingRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "validators", validatorAddress, "outstanding_rewards")
                .GetJsonAsync<ResponseWithHeight<IList<DecCoin>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<DecCoin>> GetValidatorOutstandingRewards(string validatorAddress)
        {
            return GetValidatorOutstandingRewardsAsync(validatorAddress)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<DecCoin>>> GetValidatorRewardsAsync(string validatorAddress, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "validators", validatorAddress, "rewards")
                .GetJsonAsync<ResponseWithHeight<IList<DecCoin>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<DecCoin>> GetValidatorRewards(string validatorAddress)
        {
            return GetValidatorRewardsAsync(validatorAddress)
                .Sync();
        }

        public Task<GasEstimateResponse> PostValidatorWithdrawRewardsSimulationAsync(string validatorAddress, WithdrawRewardsRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);

            return _clientGetter()
                .Request("distribution", "validators", validatorAddress, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostValidatorWithdrawRewardsSimulation(string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostValidatorWithdrawRewardsSimulationAsync(validatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostValidatorWithdrawRewardsAsync(string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);

            return _clientGetter()
                .Request("distribution", "validators", validatorAddress, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostValidatorWithdrawRewards(string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostValidatorWithdrawRewardsAsync(validatorAddress, request)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<DecCoin>>> GetCommunityPoolAsync(long? height = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "community_pool")
                .SetQueryParam("height", height)
                .GetJsonAsync<ResponseWithHeight<IList<DecCoin>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<DecCoin>> GetCommunityPool(long? height = default)
        {
            return GetCommunityPoolAsync(height)
                .Sync();
        }

        public Task<ResponseWithHeight<DistributionParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("distribution", "parameters")
                .GetJsonAsync<ResponseWithHeight<DistributionParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<DistributionParams> GetParams(long? height = default)
        {
            return GetParamsAsync(height)
                .Sync();
        }
    }
}