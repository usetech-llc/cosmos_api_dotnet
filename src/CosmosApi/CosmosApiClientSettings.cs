using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CosmosApi.Callbacks;
using CosmosApi.Crypto;
using CosmosApi.Models;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi
{
    /// <summary>
    /// Cosmos api configuration.
    /// </summary>
    public class CosmosApiClientSettings
    {

        public CosmosApiClientSettings()
        {
        }
        
        /// <summary>
        /// Base url of cosmos api rest server.
        /// </summary>
        public string? BaseUrl { get; set; }

        /// <summary>
        /// Specifies the username to use for the authorization.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Specifies the password to use for the authorization.
        /// </summary>
        public string? Password  { get; set; }

        /// <summary>
        /// Specifies the time to keep the underlying HTTP/TCP conneciton open. When expired, a Connection: close header
        /// is sent with the next request, which should force a new connection and DSN lookup to occur on the next call.
        /// Default is null, effectively disabling the behavior.
        /// </summary>
        public TimeSpan? ConnectionLeaseTimeout { get; set; }

        /// <summary>
        /// Defines how HttpClient should be instantiated and configured by default.
        /// Default is null, creating default HttpClient. 
        /// </summary>
        public Func<HttpMessageHandler, HttpClient>? HttpClientFactory { get; set; }

        /// <summary>
        /// Defines how HttpMessageHandler should be instantiated and configured by default.
        /// Default is null, creating default HttpMessageHandler. 
        /// </summary>
        public Func<HttpMessageHandler>? CreateMessageHandlerFactory { get; set; }

        /// <summary>Gets or sets the HTTP request timeout.</summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets a callback that is called immediately before every HTTP request is sent.
        /// </summary>
        public Action<BeforeCall>? OnBeforeCall { get; set; }

        /// <summary>
        /// Gets or sets a callback that is asynchronously called immediately before every HTTP request is sent.
        /// </summary>
        public Func<BeforeCall, Task>? OnBeforeCallAsync { get; set; }

        /// <summary>
        /// Gets or sets a callback that is called immediately after every HTTP response is received.
        /// </summary>
        public Action<AfterCall>? OnAfterCall { get; set; }

        /// <summary>
        /// Gets or sets a callback that is asynchronously called immediately after every HTTP response is received.
        /// </summary>
        public Func<AfterCall, Task>? OnAfterCallAsync { get; set; }

        /// <summary>
        /// Gets or sets a callback that is called when an error occurs during any HTTP call, including when any non-success
        /// HTTP status code is returned in the response.
        /// </summary>
        public Action<Error>? OnError { get; set; }

        /// <summary>
        /// Gets or sets a callback that is asynchronously called when an error occurs during any HTTP call, including when any non-success
        /// HTTP status code is returned in the response.
        /// </summary>
        public Func<Error, Task>? OnErrorAsync { get; set; }
        
        /// <summary>
        /// List of custom json converters. 
        /// </summary>
        public List<JsonConverter> Converters { get; set; } = new List<JsonConverter>();

        /// <summary>
        /// Set of cryptography operations.
        /// </summary>
        public ICryptoService CryptoService { get; set; } = new CosmosCryptoService();
        
        internal TypeValueConverter<ITx> TxConverter { get; } = new TypeValueConverter<ITx>($"Call {nameof(ICosmosApiBuilder)}.{nameof(ICosmosApiBuilder.RegisterTxType)} to register discriminator/type pair.");
        
        internal TypeValueConverter<IMsg> MsgConverter { get; } = new TypeValueConverter<IMsg>($"Call {nameof(ICosmosApiBuilder)}.{nameof(ICosmosApiBuilder.RegisterMsgType)} to register discriminator/type pair.");

        internal TypeValueConverter<IAccount> AccountConverter { get; } = new TypeValueConverter<IAccount>($"Call {nameof(ICosmosApiBuilder)}.{nameof(ICosmosApiBuilder.RegisterAccountType)} to register discriminator/type pair.");
        
        internal TypeValueConverter<IProposalContent> ProposalContentConverter { get; } = new TypeValueConverter<IProposalContent>($"Call {nameof(ICosmosApiBuilder)}.{nameof(ICosmosApiBuilder.RegisterAccountType)} to register discriminator/type pair.");
    }
}