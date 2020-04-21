using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class Staking : IStaking
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Staking(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "delegations")
                .GetJsonAsync<ResponseWithHeight<IList<Delegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr)
        {
            return GetDelegationsAsync(delegatorAddr)
                .Sync();
        }
    }
}