using System;
using System.Reflection;
using CosmosApi.Models;
using CosmosApi.Serialization;

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

        /// <summary>
        /// Adds a possible subtype of the <see cref="ITx"/> so it can be serialized
        /// and deserialized properly. 
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="ITx"/> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ICosmosApiBuilder RegisterTxType<T>(string jsonName) where T : ITx;

        /// <summary>
        /// Adds a possible subtype of the <see cref="IMsg"/> so it can be serialized
        /// and deserialized properly. 
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IMsg"/> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ICosmosApiBuilder RegisterMsgType<T>(string jsonName) where T : IMsg;
        
        /// <summary>
        /// Adds a possible Value type of <see cref="TypeValue{TValue}"/>.
        /// </summary>
        /// <param name="jsonName">Value of json discriminator.</param>
        /// <typeparam name="T">Type of TypeValue's Value.</typeparam>
        ICosmosApiBuilder RegisterTypeValue<T>(string jsonName);

        /// <summary>
        /// Adds a converter factory to use for serialization and deserialization.
        /// </summary>
        ICosmosApiBuilder AddJsonConverterFactory(IConverterFactory factory);
    }
}