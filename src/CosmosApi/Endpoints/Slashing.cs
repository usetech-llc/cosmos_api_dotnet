using System;
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
    }
}