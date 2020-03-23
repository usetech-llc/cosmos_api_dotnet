using System;
using System.Net.Http;
using Flurl.Http;

namespace CosmosApi
{
    public class CosmosApiClientSettings
    {
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
        public Func<HttpMessageHandler>? HttpClientFactory { get; set; }
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
        public Action<HttpCall> BeforeCall { get; set; }

    }
}