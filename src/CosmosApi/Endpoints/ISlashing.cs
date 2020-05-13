using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// Slashing module APIs.
    /// </summary>
    public interface ISlashing
    {
        /// <summary>
        /// Get sign info of a validator.
        /// </summary>
        /// <param name="publicKey">Validators public key.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<ValidatorSigningInfo>> GetSigningInfoAsync(string publicKey, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get sign info of a validator.
        /// </summary>
        /// <param name="publicKey">Validators public key.</param>
        /// <returns></returns>
        ResponseWithHeight<ValidatorSigningInfo> GetSigningInfo(string publicKey);

        /// <summary>
        /// Get sign info of given all validators.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Maximum number of items per page.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<ValidatorSigningInfo>>> GetSigningInfosAsync(int? page = default, int? limit = default, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get sign info of given all validators.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="limit">Maximum number of items per page.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<ValidatorSigningInfo>> GetSigningInfos(int? page = default, int? limit = default);
    }
}