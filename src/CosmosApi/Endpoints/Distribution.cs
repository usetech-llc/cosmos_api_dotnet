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

        public Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(WithdrawRewardsRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);

            return _clientGetter()
                .Request("distribution", "delegators", baseReq.From, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostWithdrawRewardsSimulation(WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsSimulationAsync(request)
                .Sync();
        }

        public Task<StdTx> PostWithdrawRewardsAsync(WithdrawRewardsRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);

            return _clientGetter()
                .Request("distribution", "delegators", baseReq.From, "rewards")
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostWithdrawRewards(WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsAsync(request)
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

        public Task<GasEstimateResponse> PostWithdrawRewardsSimulationAsync(string validatorAddress, WithdrawRewardsRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);

            return _clientGetter()
                .Request("distribution", "delegators", baseReq.From, "rewards", validatorAddress)
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostWithdrawRewardsSimulation(string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsSimulationAsync(validatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostWithdrawRewardsAsync(string validatorAddress, WithdrawRewardsRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);

            return _clientGetter()
                .Request("distribution", "delegators", baseReq.From, "rewards", validatorAddress)
                .PostJsonAsync(new WithdrawRewardsRequest(baseReq), cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostWithdrawRewards(string validatorAddress, WithdrawRewardsRequest request)
        {
            return PostWithdrawRewardsAsync(validatorAddress, request)
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
    }
}