using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosApi.Test
{
    public class TestConfiguration
    {
        public string GlobalBaseUrl { get; set; } = null!;
        public string LocalBaseUrl { get; set; } = null!;
        public string LocalValidator1Address { get; set; } = null!;
        public string LocalValidator2Address { get; set; } = null!;
        public string LocalValidator1PrivateKey { get; set; } = null!;
        public string LocalValidator1Passphrase { get; set; } = null!;
        public string LocalChainId { get; set; } = null!;
        public string LocalDelegator1Address { get; set; } = null!;

        private TestConfiguration()
        {
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