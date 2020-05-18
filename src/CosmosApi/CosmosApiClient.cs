using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Callbacks;
using CosmosApi.Crypto;
using CosmosApi.Endpoints;
using CosmosApi.Extensions;
using CosmosApi.Flurl;
using CosmosApi.Models;
using CosmosApi.Serialization;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using TaskTupleAwaiter;
using ISerializer = CosmosApi.Serialization.ISerializer;

namespace CosmosApi
{
    public class CosmosApiClient : ICosmosApiClient
    {
        private readonly CosmosApiClientSettings _settings;
        private Lazy<IFlurlClient>? _flurlClient;

        public CosmosApiClient(CosmosApiClientSettings settings)
        {
            _settings = settings;
            _flurlClient = new Lazy<IFlurlClient>(CreateClient, LazyThreadSafetyMode.ExecutionAndPublication);
            
            GaiaRest = new GaiaREST(GetClient);
            TendermintRpc = new TendermintRPC(GetClient);
            Transactions = new Transactions(GetClient);
            Auth = new Auth(GetClient);
            Bank = new Bank(GetClient);
            Staking = new Staking(GetClient);
            Governance = new Governance(GetClient);
            Slashing = new Slashing(GetClient);
            Distribution = new Distribution(GetClient);
            Mint = new Mint(GetClient);
            var jsonSerializerSettings = JsonSerializerSettings();
            Serializer = new NewtownJsonSerializer(jsonSerializerSettings);
        }

        public IGaiaREST GaiaRest { get; }
        public ITendermintRPC TendermintRpc { get; }
        public ITransactions Transactions { get; }
        public IAuth Auth { get; }
        public IBank Bank { get; }
        public IStaking Staking { get; }
        public IGovernance Governance { get; }
        public ISlashing Slashing { get; }
        public IDistribution Distribution { get; }
        public IMint Mint { get; }

        public HttpClient HttpClient =>
            _flurlClient?.Value.HttpClient ?? throw new ObjectDisposedException(nameof(CosmosApiClient));

        public ISerializer Serializer { get; }
        public ICryptoService CryptoService => _settings.CryptoService;

        private IFlurlClient GetClient()
        {
            return _flurlClient?.Value ?? throw new ObjectDisposedException(nameof(CosmosApiClient));
        }

        private IFlurlClient CreateClient()
        {
            var client = new FlurlClient()
                .Configure(s =>
                {
                    s.ConnectionLeaseTimeout = _settings.ConnectionLeaseTimeout;
                    s.Timeout = _settings.Timeout;
                    if (_settings.HttpClientFactory != null || _settings.CreateMessageHandlerFactory != null)
                    {
                        s.HttpClientFactory = new DelegateClientFactory(_settings.HttpClientFactory, _settings.CreateMessageHandlerFactory);
                    }
                    
                    if (_settings.OnError != null)
                    {
                        s.OnError = call =>
                        {
                            var error = new Error(call.Request, call.Response, call.StartedUtc, call.EndedUtc, call.Exception.WrapException(), call.ExceptionHandled);
                            _settings.OnError(error);
                            call.ExceptionHandled = error.Handled;
                        };
                    }
                    if (_settings.OnErrorAsync != null)
                    {
                        s.OnErrorAsync = async call =>
                        {
                            var error = new Error(call.Request, call.Response, call.StartedUtc, call.EndedUtc, call.Exception.WrapException(), call.ExceptionHandled);
                            await _settings.OnErrorAsync(error);
                            call.ExceptionHandled = error.Handled;
                        };
                    }

                    if (_settings.OnBeforeCall != null)
                    {
                        s.BeforeCall = call => _settings.OnBeforeCall(new BeforeCall(call.Request));
                    }
                    if (_settings.OnBeforeCallAsync != null)
                    {
                        s.BeforeCallAsync = call => _settings.OnBeforeCallAsync(new BeforeCall(call.Request));
                    }

                    if (_settings.OnAfterCall != null)
                    {
                        s.AfterCall = call => _settings.OnAfterCall(new AfterCall(call.Request, call.Response, call.StartedUtc, call.EndedUtc));
                    }
                    if (_settings.OnAfterCallAsync != null)
                    {
                        s.AfterCallAsync = call => _settings.OnAfterCallAsync(new AfterCall(call.Request, call.Response, call.StartedUtc, call.EndedUtc));
                    }

                    var jsonSerializerSettings = JsonSerializerSettings();

                    s.JsonSerializer = new NewtonsoftJsonSerializer(jsonSerializerSettings);
                });
            if (_settings.BaseUrl != null)
            {
                client.BaseUrl = _settings.BaseUrl;
                client.HttpClient.BaseAddress = new Uri(_settings.BaseUrl);
            }

            if (_settings.Username != null && _settings.Password != null)
            {
                client = client.WithBasicAuth(_settings.Username, _settings.Password);
            }

            return client;
        }

        private JsonSerializerSettings JsonSerializerSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
            };

            foreach (var converter in _settings.Converters)
            {
                jsonSerializerSettings.Converters.Add(converter);
            }

            jsonSerializerSettings.Converters.Add(new BigDecimalConverter());
            if (_settings.MsgConverter.JsonNameToType.Any())
            {
                jsonSerializerSettings.Converters.Add(_settings.MsgConverter);
            }
            if (_settings.TxConverter.JsonNameToType.Any())
            {
                jsonSerializerSettings.Converters.Add(_settings.TxConverter);
            }
            if (_settings.AccountConverter.JsonNameToType.Any())
            {
                jsonSerializerSettings.Converters.Add(_settings.AccountConverter);
            }
            if (_settings.ProposalContentConverter.JsonNameToType.Any())
            {
                jsonSerializerSettings.Converters.Add(_settings.ProposalContentConverter);
            }
            return jsonSerializerSettings;
        }

        public void Dispose()
        {
            if (_flurlClient?.IsValueCreated == true)
            {
                _flurlClient.Value.Dispose();
                _flurlClient = null;
            }
        }
    }
}