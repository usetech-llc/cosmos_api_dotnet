using System;
using CosmosApi.CosmosClient;

namespace CosmosApi
{
    public interface ICosmosApiClient
    {
        ICosmosApiClient Configure(Action<CosmosApiClientSettings> configurator);
        IGaiaREST GaiaRest { get; }
    }
}