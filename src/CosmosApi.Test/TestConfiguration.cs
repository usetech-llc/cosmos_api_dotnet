using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosApi.Test
{
    public class TestConfiguration
    {
        public string LocalBaseUrl { get; set; } = null!;
        public string LocalAccount1Address { get; set; } = null!;
        public string LocalAccount2Address { get; set; } = null!;
        public string LocalAccount1PrivateKey { get; set; } = null!;
        public string LocalAccount2PrivateKey { get; set; } = null!;
        public string LocalAccount1Passphrase { get; set; } = null!;
        public string LocalAccount2Passphrase { get; set; } = null!;
        public string LocalDelegator1Address { get; set; } = null!;
        public string LocalDelegator1PrivateKey { get; set; } = null!;
        public string LocalDelegator1Passphrase { get; set; } = null!;
        public string LocalValidator1Address { get; set; } = null!;
        public string LocalValidator2Address { get; set; } = null!;
        public bool CutLongOutput { get; set; } = false;
        public string LocalNameserviceBaseUrl { get; set; } = null!;
        public string LocalNameserviceOwner1 { get; set; } = null!;
        public string LocalNameserviceOwner1PrivateKey { get; set; } = null!;
        public string LocalNameserviceOwner1Passphrase { get; set; } = null!;
        

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