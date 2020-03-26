using System.Threading.Tasks;
using Xunit;

namespace CosmosApi.Test.Endpoints
{
    public class GaiaRestTest : BaseTest
    {
        [Fact]
        public async Task AsyncGetNodeInfoCompletes()
        {
            using var client = CreateClient();

            var nodeInfo = await client.GaiaRest.GetNodeInfoAsync();
        }

        [Fact]
        public void SyncGetNodeInfoCompletes()
        {
            using var client = CreateClient();

            var nodeInfo = client.GaiaRest.GetNodeInfo();
        }
    }
}