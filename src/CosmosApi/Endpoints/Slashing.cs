using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class Slashing : ISlashing
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Slashing(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<ValidatorSigningInfo>> GetSigningInfoAsync(string publicKey, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("slashing", "validators", publicKey, "signing_info")
                .GetJsonAsync<ResponseWithHeight<ValidatorSigningInfo>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<ValidatorSigningInfo> GetSigningInfo(string publicKey)
        {
            return GetSigningInfoAsync(publicKey)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<ValidatorSigningInfo>>> GetSigningInfosAsync(int? page = default, int? limit = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("slashing", "signing_infos")
                .SetQueryParam("page", page)
                .SetQueryParam("limit", limit)
                .GetJsonAsync<ResponseWithHeight<IList<ValidatorSigningInfo>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<ValidatorSigningInfo>> GetSigningInfos(int? page = default, int? limit = default)
        {
            return GetSigningInfosAsync(page, limit)
                .Sync();
        }

        public Task<GasEstimateResponse> PostUnjailSimulationAsync(string validatorAddress, UnjailRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new UnjailRequest(baseReq);
            return _clientGetter()
                .Request("slashing", "validators", validatorAddress, "unjail")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostUnjailSimulation(string validatorAddress, UnjailRequest request)
        {
            return PostUnjailSimulationAsync(validatorAddress, request)
                .Sync();
        }

        public Task<StdTx> PostUnjailAsync(string validatorAddress, UnjailRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new UnjailRequest(baseReq);
            return _clientGetter()
                .Request("slashing", "validators", validatorAddress, "unjail")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostUnjail(string validatorAddress, UnjailRequest request)
        {
            return PostUnjailAsync(validatorAddress, request)
                .Sync();
        }

        public Task<ResponseWithHeight<SlashingParams>> GetParametersAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("slashing", "parameters")
                .GetJsonAsync<ResponseWithHeight<SlashingParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<SlashingParams> GetParameters()
        {
            return GetParametersAsync()
                .Sync();
        }
    }
}