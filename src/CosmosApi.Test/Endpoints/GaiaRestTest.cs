using System.Threading.Tasks;
using Xunit;

namespace CosmosApi.Test.Endpoints
{
    public class GaiaRestTest
    {
        [Fact]
        public async Task AsyncGetNodeInfoCompletes()
        {
            using var client = new CosmosApiBuilder()
                .UseBaseUrl("https://api.cosmos.network")
                .CreateClient();

            var nodeInfo = await client.GaiaRest.GetNodeInfoAsync();
        }

        [Fact]
        public void SyncGetNodeInfoCompletes()
        {
            using var client = new CosmosApiBuilder()
                .UseBaseUrl("https://api.cosmos.network")
                .CreateClient();

            var nodeInfo = client.GaiaRest.GetNodeInfo();
        }
    }
}