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
        public TendermintRpcTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncSyncingCompletes()
        {
            using var client = CreateClient();

            var syncData = await client.TendermintRpc.GetSyncingAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(syncData);
        }
        
        [Fact]
        public void SyncSyncingCompletes()
        {
            using var client = CreateClient();

            var syncData = client.TendermintRpc.GetSyncing();
            OutputHelper.WriteLine("Deserialized into");
            Dump(syncData);
        }

        [Fact]
        public async Task AsyncLatestBlockCompletes()
        {
            using var client = CreateClient();

            var block = await client.TendermintRpc.GetLatestBlockAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
        }

        [Fact]
        public void SyncLatestBlockCompletes()
        {
            using var client = CreateClient();

            var block = client.TendermintRpc.GetLatestBlock();
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
        }

        [Fact]
        public async Task AsyncBlockByHeightCompletes()
        {
            using var client = CreateClient();

            var block = await client.TendermintRpc.GetBlockByHeightAsync(5);
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
        }

        //[Fact]
        //Todo: uncomment when ExpectedObject will be able to handle DateTimeOffset or there will be some replacement for ExpectedObject
        private async Task AsyncBlockByHeight3rdBlockIsCorrect()
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
                OutputHelper.WriteLine("Deserialized into");
                Dump(block);
            }
            catch (CosmosHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
            }
        }

        [Fact]
        public void SyncBlockByHeightCompletes()
        {
            using var client = CreateClient();

            var block = client.TendermintRpc.GetBlockByHeight(1);
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
        }

        [Fact]
        public void SyncBlockByHeightWithMaxLongHeightFailsWith404()
        {
            using var client = CreateClient();

            try
            {
                var block = client.TendermintRpc.GetBlockByHeight(long.MaxValue);
                OutputHelper.WriteLine("Deserialized into");
                Dump(block);
            }
            catch (CosmosHttpException exception)
            {
                Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
            }
        }

        //[Fact]
        //Todo: uncomment when ExpectedObject will be able to handle DateTimeOffset or there will be some replacement for ExpectedObject
        private void SyncBlockByHeight3rdBlockIsCorrect()
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
            OutputHelper.WriteLine("Deserialized into");
            Dump(validatorSet);
        }
        
        [Fact]
        public void SyncLatestValidatorSetCompletes()
        {
            using var client = CreateClient();

            var validatorSet = client.TendermintRpc.GetLatestValidatorSet();
            OutputHelper.WriteLine("Deserialized into");
            Dump(validatorSet);
        }
        
        //[Fact]
        //Todo: uncomment when ExpectedObject will be able to handle DateTimeOffset or there will be some replacement for ExpectedObject
        private async Task AsyncValidatorSetByHeightFirstSetIsCorrect()
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
                OutputHelper.WriteLine("Deserialized into");
                Dump(validatorSet);
            }
            catch (CosmosHttpException ex)
            {
                Assert.Equal(HttpStatusCode.NotFound, ex.Response?.StatusCode);
            }

        }
                
        //[Fact]
        //Todo: uncomment when ExpectedObject will be able to handle DateTimeOffset or there will be some replacement for ExpectedObject
        private void SyncValidatorSetByHeightFirstSetIsCorrect()
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
                OutputHelper.WriteLine("Deserialized into");
                Dump(validatorSet);
            }
            catch (CosmosHttpException ex)
            {
                Assert.Equal(HttpStatusCode.NotFound, ex.Response?.StatusCode);
            }
        }
    }
}