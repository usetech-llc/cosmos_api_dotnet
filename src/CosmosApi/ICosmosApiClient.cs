using System;
using CosmosApi.Endpoints;

namespace CosmosApi
{
    public interface ICosmosApiClient : IDisposable
    {
        IGaiaREST GaiaRest { get; }
        ITendermintRPC TendermintRpc { get; }
        ITransactions Transactions { get; }
        IAuth Auth { get; }
    }
}