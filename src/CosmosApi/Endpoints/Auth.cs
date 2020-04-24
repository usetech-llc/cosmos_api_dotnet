using System;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    public class Auth : IAuth
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Auth(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }

        public Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _clientGetter()
                .Request("auth", "accounts", address)
                .GetJsonAsync<ResponseWithHeight<IAccount>>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address)
        {
            return GetAuthAccountByAddressAsync(address)
                .Sync();
        }
    }
}