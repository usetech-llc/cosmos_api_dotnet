using CosmosApi.Models;

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
                .RegisterTxType<StdTx>("cosmos-sdk/StdTx")
                .RegisterMsgType<MsgMultiSend>("cosmos-sdk/MsgMultiSend")
                .RegisterMsgType<MsgSend>("cosmos-sdk/MsgSend")
                .CreateClient();
        }
    }
}