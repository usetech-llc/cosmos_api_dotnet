using System;
using CosmosApi;

namespace NameserviceApi
{
    public static class CosmosApiClientExtensions
    {
        public static INameservice CreateNameservice(this ICosmosApiClient cosmosApiClient)
        {
            return new Nameservice(cosmosApiClient);
        }
    }
}