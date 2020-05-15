using System;
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
    }
}