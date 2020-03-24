using System;

namespace CosmosApi
{
    /// <summary>
    /// Interface for setting client configuration before creating.
    /// </summary>
    public interface ICosmosApiBuilder
    {
        /// <summary>
        /// Creates a new instance of Cosmos Api Client.
        /// </summary>
        ICosmosApiClient CreateClient();
        /// <summary>
        /// Sets settings of created clients using Action. 
        /// </summary>
        ICosmosApiBuilder Configure(Action<CosmosApiClientSettings> configurator);
        /// <summary>
        /// Sets username and password authorization for created clients. 
        /// </summary>
        ICosmosApiBuilder UseAuthorization(string username, string password);
        /// <summary>
        /// Sets the base url used by created clients. 
        /// </summary>
        ICosmosApiBuilder UseBaseUrl(string url);
    }
}