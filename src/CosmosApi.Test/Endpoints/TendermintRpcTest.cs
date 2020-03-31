using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CosmosApi.Test.TestData;
using ExpectedObjects;
using Flurl.Http;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class TendermintRpcTest : BaseTest
    {
        private readonly ITestOutputHelper output;

        public TendermintRpcTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
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
        public async Task SyncLatestBlockCompletes()
        {
            using var client = CreateClient();

            try
            {
                var block = client.TendermintRpc.GetLatestBlock();
            }
            catch (CosmosHttpException ex)
            {
                if (ex.Response != null)
                {
                    output.WriteLine($"Exception, status code: {ex.Response.StatusCode}");
                    output.WriteLine($"Headers: {string.Join(Environment.NewLine, ex.Response.Headers.Select(h => $"{h.Key}: {h.Value}"))}");
                    
                    var responseContent = await ex.Response.Content.ReadAsStringAsync();
                    output.WriteLine("");
                    output.WriteLine($"Response content was: {responseContent}");
                }

                throw;
            }
        }

        [Fact]
        public async Task AsyncBlockByHeightCompletes()
        {
            using var client = CreateClient();

            for (int i = 1; i < 5; i++)
            {
                var block = await client.TendermintRpc.GetBlockByHeightAsync(i);
            }
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
            catch (CosmosHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Response.StatusCode);
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
            catch (CosmosHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Response.StatusCode);
            }
        }

        [Fact]
        public void SyncBlockByHeight3rdBlockIsCorrect()
        {
            using var client = CreateClient();

            var block = client.TendermintRpc.GetBlockByHeight(3);
            var expectedBlock = Blocks.BlockQueryHeight3().ToExpectedObject();
            expectedBlock.ShouldEqual(block);
        }

        [Fact]
        public async Task AsyncLatestValidatorSetCompletes()
        {
            using var client = CreateClient();

            var validatorSet = await client.TendermintRpc.GetLatestValidatorSetAsync();
        }
        
        [Fact]
        public void SyncLatestValidatorSetCompletes()
        {
            using var client = CreateClient();

            var validatorSet = client.TendermintRpc.GetLatestValidatorSetAsync();
        }
        
        [Fact]
        public async Task AsyncValidatorSetByHeightFirstSetIsCorrect()
        {
            using var client = CreateClient();

            var validatorSet = await client.TendermintRpc.GetValidatorSetByHeightAsync(1);
            var expectedValidatorSet = ValidatorSets
                .FirstValidatorSet()
                .ToExpectedObject();
            
            expectedValidatorSet.ShouldEqual(validatorSet);
        }

        [Fact]
        public async Task AsyncValidatorSetByHeightMaxLongHeightFailsWith404()
        {
            using var client = CreateClient();

            try
            {
                var validatorSet = await client.TendermintRpc.GetValidatorSetByHeightAsync(long.MaxValue);
            }
            catch (CosmosHttpException ex)
            {
                Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }

        }
                
        [Fact]
        public void SyncValidatorSetByHeightFirstSetIsCorrect()
        {
            using var client = CreateClient();

            var validatorSet = client.TendermintRpc.GetValidatorSetByHeight(1);
            var expectedValidatorSet = ValidatorSets
                .FirstValidatorSet()
                .ToExpectedObject();
            
            expectedValidatorSet.ShouldEqual(validatorSet);
        }

        [Fact]
        public void SyncValidatorSetByHeightMaxLongHeightFailsWith404()
        {
            using var client = CreateClient();

            try
            {
                var validatorSet = client.TendermintRpc.GetValidatorSetByHeight(long.MaxValue);
            }
            catch (CosmosHttpException ex)
            {
                Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }
    }
}