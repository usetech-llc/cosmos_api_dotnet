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
    }
}