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

        public Task<ResponseWithHeight<ValidatorSet>> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("validatorsets", "latest")
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<ValidatorSet> GetLatestValidatorSet()
        {
            return GetLatestValidatorSetAsync().Sync();
        }

        public Task<ResponseWithHeight<ValidatorSet>> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("validatorsets", height)
                .GetJsonAsync<ResponseWithHeight<ValidatorSet>>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<ValidatorSet> GetValidatorSetByHeight(long height)
        {
            return GetValidatorSetByHeightAsync(height).Sync();
        }
    }
}