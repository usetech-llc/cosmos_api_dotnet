using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// TendermintRPC operations.
    /// </summary>
    public interface ITendermintRPC
    {
        /// <summary>
        /// Syncing state of node
        /// </summary>
        /// <remarks>
        /// Get if the node is currently syning with other nodes
        /// </remarks>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<NodeSyncingStatus> GetSyncingAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Syncing state of node
        /// </summary>
        /// <remarks>
        /// Get if the node is currently syning with other nodes
        /// </remarks>
        NodeSyncingStatus GetSyncing();
        
        /// <summary>
        /// Get the latest block
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<BlockQuery> GetLatestBlockAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the latest block
        /// </summary>
        BlockQuery GetLatestBlock();
        
        /// <summary>
        /// Get a block at a certain height
        /// </summary>
        /// <param name='height'>
        /// Block height
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<BlockQuery> GetBlockByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get a block at a certain height
        /// </summary>
        /// <param name='height'>
        /// Block height
        /// </param>
        BlockQuery GetBlockByHeight(long height);
        
        /// <summary>
        /// Get the latest validator set
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ValidatorSet> GetLatestValidatorSetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the latest validator set
        /// </summary>
        ValidatorSet GetLatestValidatorSet();
        
        /// <summary>
        /// Get a validator set a certain height
        /// </summary>
        /// <param name='height'>
        /// Block height
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ValidatorSet> GetValidatorSetByHeightAsync(long height, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a validator set a certain height
        /// </summary>
        /// <param name='height'>
        /// Block height
        /// </param>
        ValidatorSet GetValidatorSetByHeight(long height);
    }
}
