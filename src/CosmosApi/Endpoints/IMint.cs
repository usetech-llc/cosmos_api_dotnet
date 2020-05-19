using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;
using ExtendedNumerics;

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

        /// <summary>
        /// Current minting inflation value.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<BigDecimal>> GetInflationAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Current minting inflation value.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<BigDecimal> GetInflation();

        /// <summary>
        /// Current minting annual provisions value.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<BigDecimal>> GetAnnualProvisionsAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Current minting annual provisions value.
        /// </summary>
        /// <returns></returns>
        ResponseWithHeight<BigDecimal> GetAnnualProvisions();
    }
}