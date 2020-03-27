using System;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class TendermintRPC : ITendermintRPC
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public TendermintRPC(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<NodeSyncingStatus> GetSyncingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("syncing")
                .GetJsonAsync<NodeSyncingStatus>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }

        public NodeSyncingStatus GetSyncing()
        {
            return GetSyncingAsync().Sync();
        }

        public Task<BlockQuery> GetLatestBlockAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("blocks", "latest")
                .GetJsonAsync<BlockQuery>(cancellationToken)
                .WrapExceptions();
        }

        public BlockQuery GetLatestBlock()
        {
            return GetLatestBlockAsync().Sync();
        }

        public Task<BlockQuery> GetBlockByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("blocks", height)
                .GetJsonAsync<BlockQuery>(cancellationToken)
                .WrapExceptions();
        }

        public BlockQuery GetBlockByHeight(long height)
        {
            return GetBlockByHeightAsync(height).Sync();
        }

        public Task<ValidatorSet> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ValidatorSet GetLatestValidatorSet()
        {
            throw new NotImplementedException();
        }

        public Task<ValidatorSet> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ValidatorSet GetValidatorSetByHeight(long height)
        {
            throw new NotImplementedException();
        }
    }
}