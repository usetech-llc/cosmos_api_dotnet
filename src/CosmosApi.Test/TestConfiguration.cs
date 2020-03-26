namespace CosmosApi.Test
{
    public class TestConfiguration
    {
        public string BaseUrl { get; }
        
        private TestConfiguration(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public static TestConfiguration Create()
        {
            return new TestConfiguration("https://api.cosmos.network");
        }
    }
}