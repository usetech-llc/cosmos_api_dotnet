using System.Threading.Tasks;
using CosmosApi.Test.TestData;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class GaiaRestTest : BaseTest
    {
        public GaiaRestTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
        
        [Fact]
        public async Task AsyncGetNodeInfoCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var nodeInfo = await client.GaiaRest.GetNodeInfoAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);
            
            NodeInfoData
                .NodeStatus
                .ToExpectedObject()
                .ShouldEqual(nodeInfo);
        }

        [Fact]
        public void SyncGetNodeInfoCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var nodeInfo = client.GaiaRest.GetNodeInfo();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);

            NodeInfoData
                .NodeStatus
                .ToExpectedObject()
                .ShouldEqual(nodeInfo);
        }
    }
}