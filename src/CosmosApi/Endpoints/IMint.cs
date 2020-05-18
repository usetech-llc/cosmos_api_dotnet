using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    public interface IMint
    {
        /// <summary>
        /// Minting module parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<MintParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default);
        /// <summary>
        /// Minting module parameters.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        ResponseWithHeight<MintParams> GetParams(long? height = default);
    }
}