using System.Net;
using System.Threading.Tasks;
using CosmosApi.Test.TestData;
using ExpectedObjects;
using Flurl.Http;
using Xunit;

namespace CosmosApi.Test.Endpoints
{
    public class TendermintRpcTest : BaseTest
    {
        [Fact]
        public async Task AsyncSyncingCompletes()
        {
            using var client = CreateClient();

            var syncData = await client.TendermintRpc.GetSyncingAsync();
        }
        
        [Fact]
        public void SyncSyncingCompletes()
        {
            using var client = CreateClient();

            var syncData = client.TendermintRpc.GetSyncing();
        }

        [Fact]
        public async Task AsyncLatestBlockCompletes()
        {
            using var client = CreateClient();

            var block = await client.TendermintRpc.GetLatestBlockAsync();
            
        }

        [Fact]
        public void SyncLatestBlockCompletes()
        {
            using var client = CreateClient();

            var block = client.TendermintRpc.GetLatestBlock();
        }

        [Fact]
        public async Task AsyncBlockByHeightCompletes()
        {
            using var client = CreateClient();

            var block = await client.TendermintRpc.GetBlockByHeightAsync(1);
        }

        [Fact]
        public async Task AsyncBlockByHeight3rdBlockIsCorrect()
        {
            using var client = CreateClient();

            var block = await client.TendermintRpc.GetBlockByHeightAsync(3);
            var expectedBlock = Blocks.BlockQueryHeight3().ToExpectedObject();
            expectedBlock.ShouldEqual(block);
        }

        [Fact]
        public async Task AsyncBlockByHeightWithMaxLongHeightFailsWith404()
        {
            using var client = CreateClient();

            try
            {
                var block = await client.TendermintRpc.GetBlockByHeightAsync(long.MaxValue);
            }
            catch (FlurlHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Call.HttpStatus);
            }
        }

        [Fact]
        public void SyncBlockByHeightCompletes()
        {
            using var client = CreateClient();

            var block = client.TendermintRpc.GetBlockByHeight(1);
        }

        [Fact]
        public void SyncBlockByHeightWithMaxLongHeightFailsWith404()
        {
            using var client = CreateClient();

            try
            {
                var block = client.TendermintRpc.GetBlockByHeight(long.MaxValue);
            }
            catch (FlurlHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Call.HttpStatus);
            }
        }
    }
}