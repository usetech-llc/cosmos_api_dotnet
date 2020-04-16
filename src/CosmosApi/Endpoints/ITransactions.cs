using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    ///  Search, encode, or broadcast transactions.
    /// </summary>
    public interface ITransactions
    {
        /// <summary>
        /// Search transactions.
        /// </summary>
        /// <param name="messageAction">
        /// Transaction events such as ‘send’. Note that each module documents its own events. look for xx_events.md in the corresponding cosmos-sdk/docs/spec directory.
        /// </param>
        /// <param name="messageSender">
        /// Transaction tags with sender.
        /// </param>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="limit">
        /// Maximum number of items per page
        /// </param>
        /// <param name="minHeight">
        /// Transactions on blocks with height greater or equal this value
        /// </param>
        /// <param name="maxHeight">
        /// transactions on blocks with height less than or equal this value
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<PaginatedTxs> GetSearchAsync(string? messageAction, string? messageSender, int? page = default, int? limit = default, int? minHeight = default, int? maxHeight = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search transactions.
        /// </summary>
        /// <param name="messageAction">
        /// Transaction events such as ‘send’. Note that each module documents its own events. look for xx_events.md in the corresponding cosmos-sdk/docs/spec directory.
        /// </param>
        /// <param name="messageSender">
        /// Transaction tags with sender.
        /// </param>
        /// <param name="page">
        /// Page number.
        /// </param>
        /// <param name="limit">
        /// Maximum number of items per page
        /// </param>
        /// <param name="minHeight">
        /// Transactions on blocks with height greater or equal this value
        /// </param>
        /// <param name="maxHeight">
        /// transactions on blocks with height less than or equal this value
        /// </param>
        PaginatedTxs GetSearch(string? messageAction, string? messageSender, int? page = default, int? limit = default, int? minHeight = default, int? maxHeight = default);

        /// <summary>
        /// Get a Tx by hash
        /// Retrieve a transaction using its hash.
        /// </summary>
        /// <param name="hash">Tx hash</param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<TxResponse> GetByHashAsync(byte[] hash, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get a Tx by hash
        /// Retrieve a transaction using its hash.
        /// </summary>
        /// <param name="hash">Tx hash</param>
        TxResponse GetByHash(byte[] hash);

        /// <summary>
        /// Broadcast a signed tx to a full node.
        /// </summary>
        /// <param name="txBroadcast">
        /// The tx must be a signed StdTx.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        Task<BroadcastTxResult> PostBroadcastAsync(BroadcastTxBody txBroadcast, CancellationToken cancellationToken = default);

        /// <summary>
        /// Broadcast a signed tx to a full node.
        /// </summary>
        /// <param name="txBroadcast">
        /// The tx must be a signed StdTx.
        /// </param>
        BroadcastTxResult PostBroadcast(BroadcastTxBody txBroadcast);
        
        /// <summary>
        /// Encode a transaction to the Amino wire format.
        /// Encode a transaction (signed or not) from JSON to base64-encoded Amino serialized bytes.
        /// </summary>
        /// <param name="tx">
        /// The tx to encode.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns></returns>
        Task<EncodeTxResponse> PostEncodeAsync(ITx tx, CancellationToken cancellationToken = default);

    }
}
