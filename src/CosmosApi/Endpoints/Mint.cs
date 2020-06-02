using System;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using ExtendedNumerics;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    public class Mint : IMint
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Mint(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<MintParams>> GetParamsAsync(long? height = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "parameters")
                .GetJsonAsync<ResponseWithHeight<MintParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<MintParams> GetParams(long? height = default)
        {
            return GetParamsAsync(height)
                .Sync();
        }

        public Task<ResponseWithHeight<BigDecimal>> GetInflationAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "inflation")
                .GetJsonAsync<ResponseWithHeight<BigDecimal>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<BigDecimal> GetInflation()
        {
            return GetInflationAsync()
                .Sync();
        }

        public Task<ResponseWithHeight<BigDecimal>> GetAnnualProvisionsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("minting", "annual-provisions")
                .GetJsonAsync<ResponseWithHeight<BigDecimal>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<BigDecimal> GetAnnualProvisions()
        {
            return GetAnnualProvisionsAsync()
                .Sync();
        }
    }
}