using System;
using System.Collections.Immutable;

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
    }
}