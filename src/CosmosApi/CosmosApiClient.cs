using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
using NBitcoin.Secp256k1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        }

        public IGaiaREST GaiaRest { get; }
        public ITendermintRPC TendermintRpc { get; }
        public ITransactions Transactions { get; }
        public IAuth Auth { get; }
        public IBank Bank { get; }
        
        public async Task<BroadcastTxResult> SendAsync(string chainId, string fromAddress, string toAddress, IList<Coin> coins, BroadcastTxMode mode, StdFee fee, string privateKey, string passphrase, string memo = "" , CancellationToken cancellationToken = default)
        {
            var account = await Auth.GetAuthAccountByAddressAsync(fromAddress, cancellationToken);
            
            var msg = new MsgSend()
            {
                FromAddress = fromAddress,
                ToAddress = toAddress,
                Amount = coins,
            };
            var signMsg = new StdSignDoc()
            {
                Fee = fee,
                Memo = memo,
                Messages = new List<TypeValue<IMsg>>
                {
                    new TypeValue<IMsg>(msg), 
                },
                Sequence = account.Result.Value.GetSequence(),
                AccountNumber = account.Result.Value.GetAccountNumber(),
                ChainId = chainId
            };
            var bytesToSign = GetSignBytes(signMsg);
            var key = KeysParser.Parse(privateKey, passphrase);
            var signedBytes = Sign(bytesToSign, key);
            var tx = new StdTx()
            {
                Msg = new List<TypeValue<IMsg>>() { new TypeValue<IMsg>(msg) },
                Memo = memo,
                Fee = fee,
                Signatures = new List<StdSignature>()
                {
                    new StdSignature()
                    {
                        Signature = signedBytes,
                        PubKey = account.Result.Value.GetPublicKey()
                    }
                },
            };
            
            cancellationToken.ThrowIfCancellationRequested();
            return await Transactions.PostBroadcastAsync(new BroadcastTxBody(tx, mode), cancellationToken);
        }

        internal byte[] Sign(byte[] bytesToSign, byte[] key)
        {
            using var sha = new SHA256Managed();
            var hashed = sha.ComputeHash(bytesToSign);
            var ecKey = Context.Instance.CreateECPrivKey(key);
            var signature = ecKey.SignECDSARFC6979(hashed);
            var signedBytes = new byte[64];
            signature.WriteCompactToSpan(signedBytes);
            return signedBytes;
        }

        internal byte[] GetSignBytes(StdSignDoc signMsg)
        {
            var jsonSerializerSettings = JsonSerializerSettings();
            var jObject = JObject.FromObject(signMsg, JsonSerializer.Create(jsonSerializerSettings));
            JsonSorting.SortJson(jObject);
            var json = jObject.ToString(Formatting.None, jsonSerializerSettings.Converters.ToArray());
            return Encoding.UTF8.GetBytes(json);
        }

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

            foreach (var factory in _settings.ConverterFactories)
            {
                //jsonSerializerSettings.Converters.Add(factory.CreateConverter());
            }

            jsonSerializerSettings.Converters.Add(_settings.TypeValueConverter);
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