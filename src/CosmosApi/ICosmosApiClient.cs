using System;
using CosmosApi.Endpoints;

namespace CosmosApi
{
    public interface ICosmosApiClient : IDisposable
    {
        IGaiaREST GaiaRest { get; }
    }
}