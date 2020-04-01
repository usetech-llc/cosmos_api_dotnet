using System.Threading.Tasks;
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
            using var client = CreateClient();

            var nodeInfo = await client.GaiaRest.GetNodeInfoAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);
        }

        [Fact]
        public void SyncGetNodeInfoCompletes()
        {
            using var client = CreateClient();

            var nodeInfo = client.GaiaRest.GetNodeInfo();
            OutputHelper.WriteLine("Deserialized into");
            Dump(nodeInfo);
        }
    }
}