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
    }
}