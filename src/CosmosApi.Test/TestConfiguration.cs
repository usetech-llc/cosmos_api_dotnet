using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosApi.Test
{
    public class TestConfiguration
    {
        public string GlobalBaseUrl { get; set; } = null!;
        public string LocalBaseUrl { get; set; } = null!;
        public string Validator1Address { get; set; } = null!;
        public string Validator2Address { get; set; } = null!;
        public string Validator1PrivateKey { get; set; } = null!;
        public string Validator1Passphrase { get; set; } = null!;
        public string LocalChainId { get; set; } = null!;

        private TestConfiguration()
        {
        }

        private TestConfiguration(string globalBaseUrl, string localBaseUrl, string validator1Address, string validator2Address, string validator1PrivateKey, string validator1Passphrase, string localChainId)
        {
            GlobalBaseUrl = globalBaseUrl;
            LocalBaseUrl = localBaseUrl;
            Validator1Address = validator1Address;
            Validator2Address = validator2Address;
            Validator1PrivateKey = validator1PrivateKey;
            Validator1Passphrase = validator1Passphrase;
            LocalChainId = localChainId;
        }

        public static TestConfiguration Create()
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddYamlFile("TestConfiguration.yml")
                .AddEnvironmentVariables()
                .Build();
            var testConfiguration = new TestConfiguration();
            configurationRoot.Bind(testConfiguration);
            return testConfiguration;
        }
    }
}