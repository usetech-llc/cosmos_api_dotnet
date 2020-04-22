using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using CosmosApi.Models;
using CosmosApi.Serialization;

namespace CosmosApi
{
    public class CosmosApiBuilder : ICosmosApiBuilder
    {
        private readonly ImmutableList<Action<CosmosApiClientSettings>> _settingConfigurators = ImmutableList.Create<Action<CosmosApiClientSettings>>();

        internal CosmosApiBuilder(ImmutableList<Action<CosmosApiClientSettings>> settingConfigurators)
        {
            _settingConfigurators = settingConfigurators;
        }

        public CosmosApiBuilder()
        {
        }

        public ICosmosApiClient CreateClient()
        {
            var settings = new CosmosApiClientSettings();
            foreach (var configurator in _settingConfigurators)
            {
                configurator(settings);
            }
            
            return new CosmosApiClient(settings);
        }

        public ICosmosApiBuilder Configure(Action<CosmosApiClientSettings> configurator)
        {
            return new CosmosApiBuilder(_settingConfigurators.Add(configurator));
        }

        public ICosmosApiBuilder UseAuthorization(string username, string password)
        {
            return Configure(s =>
            {
                s.Password = password;
                s.Username = username;
            });
        }

        public ICosmosApiBuilder UseBaseUrl(string url)
        {
            return Configure(s => s.BaseUrl = url);
        }

        public ICosmosApiBuilder RegisterTxType<T>(string jsonName) where T : ITx
        {
            return Configure(s => { s.TxConverterFactory.Subtypes.Add((typeof(T), jsonName)); });
        }

        public ICosmosApiBuilder RegisterMsgType<T>(string jsonName) where T : IMsg
        {
            return Configure(s => { s.MsgConverterFactory.Subtypes.Add((typeof(T), jsonName)); });
        }

        public ICosmosApiBuilder RegisterTypeValue<T>(string jsonName)
        {
            return Configure(s => { s.TypeValueConverter.AddType<T>(jsonName); });
        }

        public ICosmosApiBuilder RegisterStandartTypeValues()
        {
            return RegisterTypeValue<StdTx>("cosmos-sdk/StdTx")
                .RegisterTypeValue<MsgMultiSend>("cosmos-sdk/MsgMultiSend")
                .RegisterTypeValue<MsgSend>("cosmos-sdk/MsgSend")
                .RegisterTypeValue<BaseAccount>("cosmos-sdk/Account")
                .RegisterTypeValue<MsgDelegate>("cosmos-sdk/MsgDelegate");
        }

        public ICosmosApiBuilder AddJsonConverterFactory(IConverterFactory factory)
        {
            return Configure(s => s.ConverterFactories.Add(factory));
        }
    }
}