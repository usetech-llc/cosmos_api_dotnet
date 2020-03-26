namespace CosmosApi.Test.Endpoints
{
    public class BaseTest
    {
        public TestConfiguration Configuration { get; set; }
        
        public BaseTest()
        {
            Configuration = TestConfiguration.Create();
        }

        public ICosmosApiClient CreateClient()
        {
            return new CosmosApiBuilder()
                .UseBaseUrl(Configuration.BaseUrl)
                .CreateClient();
        }
    }
}