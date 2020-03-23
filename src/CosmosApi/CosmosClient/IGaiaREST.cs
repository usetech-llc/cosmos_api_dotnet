using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.CosmosClient
{

    /// <summary>
    /// GaiaREST operations.
    /// </summary>
    public partial interface IGaiaREST
    {
        /// <summary>
        /// The properties of the connected node
        /// </summary>
        /// <remarks>
        /// Information about the connected node
        /// </remarks>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        Task<NodeStatus> GetNodeInfoWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
