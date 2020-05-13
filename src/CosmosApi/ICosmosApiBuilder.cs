using System;
using CosmosApi.Models;
using Newtonsoft.Json;

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
        /// Adds a possible subtype of the <see cref="IAccount"/> so it can be serialized
        /// and deserialized properly. 
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IAccount"/> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ICosmosApiBuilder RegisterAccountType<T>(string jsonName) where T : IAccount;

        /// <summary>
        /// Adds a possible subtype of the <see cref="IProposalContent"/> so it can be serialized
        /// and deserialized properly. 
        /// </summary>
        /// <typeparam name="T">Type which might be used where <see cref="IProposalContent"/> is used.</typeparam>
        /// <param name="jsonName">Value of the type discriminator.</param>
        ICosmosApiBuilder RegisterProposalContentType<T>(string jsonName) where T : IProposalContent;
        
        /// <summary>
        /// Adds a converter factory to use for serialization and deserialization.
        /// </summary>
        ICosmosApiBuilder AddJsonConverter(JsonConverter converter);

        /// <summary>
        /// Registers json converters for types declared in cosmos sdk. 
        /// </summary>
        ICosmosApiBuilder RegisterCosmosSdkTypeConverters();
    }
}