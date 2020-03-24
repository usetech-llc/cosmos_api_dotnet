using System;
using System.Net.Http;
using Flurl.Http.Configuration;

namespace CosmosApi.Flurl
{
    internal class DelegateClientFactory : DefaultHttpClientFactory
    {
        private Func<HttpMessageHandler, HttpClient>? _httpClientFactory;
        private Func<HttpMessageHandler>? _messageHandlerFactory;

        public DelegateClientFactory(Func<HttpMessageHandler, HttpClient>? httpClientFactory, Func<HttpMessageHandler>? messageHandlerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _messageHandlerFactory = messageHandlerFactory;
        }

        public HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            return _httpClientFactory?.Invoke(handler) ?? base.CreateHttpClient(handler);
        }

        public HttpMessageHandler CreateMessageHandler()
        {
            return _messageHandlerFactory?.Invoke() ?? base.CreateMessageHandler();
        }
    }
}