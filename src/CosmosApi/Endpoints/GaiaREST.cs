using System;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class GaiaREST : IGaiaREST
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public GaiaREST(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        private Task<NodeStatus> InternalGetNodeInfoAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = _clientGetter();
            return client.Request("node_info")
                .GetJsonAsync<NodeStatus>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }
        
        public Task<NodeStatus> GetNodeInfoAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return InternalGetNodeInfoAsync(cancellationToken).WrapExceptions();
        }

        public NodeStatus GetNodeInfo()
        {
            return InternalGetNodeInfoAsync().Sync();
        }
    }
}