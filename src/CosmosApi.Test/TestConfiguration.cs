namespace CosmosApi.Test
{
    public class TestConfiguration
    {
        public string DefaultBaseUrl { get; }
        public string Validator1Address { get; }
        public string Validator2Address { get; }
        public string Validator1PrivateKey { get; }
        public string Validator1Passphrase { get; }
        public string LocalChainId { get; }

        private TestConfiguration(string defaultBaseUrl, string validator1Address, string validator2Address, string validator1PrivateKey, string validator1Passphrase, string localChainId)
        {
            DefaultBaseUrl = defaultBaseUrl;
            Validator1Address = validator1Address;
            Validator2Address = validator2Address;
            Validator1PrivateKey = validator1PrivateKey;
            Validator1Passphrase = validator1Passphrase;
            LocalChainId = localChainId;
        }

        public static TestConfiguration Create()
        {
            return new TestConfiguration(
                "https://api.cosmos.network",
                @"cosmos1ht7y9zx4n4wnvwmgyqm8309xj2yulwklj54h5j",
                @"cosmos1235em592dc22gehs9z44reqtuy2hqulndd54zt",
                @"-----BEGIN TENDERMINT PRIVATE KEY-----
kdf: bcrypt
salt: C586A3498B0298905ABE7D6DBADBCB87

FascN+0QNtdvs/Wh3PzxwHBNmPr5nh+yZA3g4aJD6CHbOPLCYnD7ozt4sZW3LvQu
Zs2mQ5J0t9siMmKCi/1RZ0CoweBz0pUKvO8Kqek=
=K7Bt
-----END TENDERMINT PRIVATE KEY-----",
                
                "11111111",
                "testing");
        }
    }
}