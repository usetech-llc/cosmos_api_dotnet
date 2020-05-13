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
    }
}