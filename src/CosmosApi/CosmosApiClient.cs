using System;
using System.Linq;
using System.Net.Http;
using CosmosApi.CosmosClient;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace CosmosApi
{
    public class CosmosApiClient : ICosmosApiClient
    {
        private CosmosApiClientSettings _settings = new CosmosApiClientSettings();

        public ICosmosApiClient Configure(Action<CosmosApiClientSettings> configurator)
        {
            configurator(_settings);
            return this;
        }

        public IGaiaREST GaiaRest { get; }
        
    }
}