using System.Net;
using System.Threading.Tasks;
using CosmosApi.Models;
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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var syncData = await client.TendermintRpc.GetSyncingAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(syncData);
        }
        
        [Fact]
        public void SyncSyncingCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var syncData = client.TendermintRpc.GetSyncing();
            OutputHelper.WriteLine("Deserialized into");
            Dump(syncData);
        }

        [Fact]
        public async Task AsyncLatestBlockNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var block = await client.TendermintRpc.GetLatestBlockAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);

            AssertBlockNotEmpty(block);
        }

        private void AssertBlockNotEmpty(BlockQuery block)
        {
            Assert.True(block.Block.Header.Height > 0);
            Assert.NotNull(block.Block.Header.Version);
            Assert.NotNull(block.Block.Header.AppHash);
            Assert.NotNull(block.Block.Header.ChainId);
            Assert.NotNull(block.Block.Header.ConsensusHash);
            Assert.NotNull(block.Block.Header.DataHash);
            Assert.NotNull(block.Block.Header.EvidenceHash);
            Assert.NotNull(block.Block.Header.ProposerAddress);
            Assert.NotNull(block.Block.Header.ValidatorsHash);
            Assert.NotNull(block.Block.Header.LastBlockId.Hash);
            Assert.NotNull(block.Block.Header.LastBlockId.Parts.Hash);
            Assert.NotNull(block.Block.Header.LastCommitHash);
            Assert.NotNull(block.Block.Header.LastResultsHash);
            Assert.NotNull(block.Block.Header.NextValidatorsHash);
        }

        [Fact]
        public void SyncLatestBlockNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var block = client.TendermintRpc.GetLatestBlock();
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);

            AssertBlockNotEmpty(block);
        }

        [Fact]
        public async Task AsyncBlockByHeightNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var block = await client.TendermintRpc.GetBlockByHeightAsync(1);
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
            
            AssertBlockNotEmpty(block);
        }

        [Fact]
        public async Task AsyncBlockByHeightWithMaxLongHeightFailsWith404()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var exception = await Assert.ThrowsAsync<CosmosHttpException>(
                () => client.TendermintRpc.GetBlockByHeightAsync(long.MaxValue)
            );
            Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
        }

        [Fact]
        public void SyncBlockByHeightCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var block = client.TendermintRpc.GetBlockByHeight(1);
            OutputHelper.WriteLine("Deserialized into");
            Dump(block);
        }

        [Fact]
        public void SyncBlockByHeightWithMaxLongHeightFailsWith404()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var exception = Assert.Throws<CosmosHttpException>(
                () => client.TendermintRpc.GetBlockByHeight(long.MaxValue)
            );
            Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
        }

        [Fact]
        public async Task AsyncLatestValidatorSetNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validatorSet = await client.TendermintRpc.GetLatestValidatorSetAsync();
            OutputHelper.WriteLine("Deserialized into");
            Dump(validatorSet);

            AssertValidatorSetNotEmpty(validatorSet.Result);
        }

        private void AssertValidatorSetNotEmpty(ValidatorSet validatorSet)
        {
            Assert.True(validatorSet.BlockHeight > 0);
            Assert.NotEmpty(validatorSet.Validators);
            Assert.All(validatorSet.Validators, v =>
            {
                Assert.NotEmpty(v.Address);
                Assert.NotEmpty(v.PubKey);
                Assert.True(v.VotingPower > 0);
            });
        }

        [Fact]
        public void SyncLatestValidatorSetNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validatorSet = client.TendermintRpc.GetLatestValidatorSet();
            OutputHelper.WriteLine("Deserialized into");
            Dump(validatorSet);
            
            AssertValidatorSetNotEmpty(validatorSet.Result);
        }
        
        [Fact]
        public async Task AsyncValidatorSetByHeightMaxLongHeightFailsWith404()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var exception = await Assert.ThrowsAsync<CosmosHttpException>(() =>
                client.TendermintRpc.GetValidatorSetByHeightAsync(long.MaxValue));
            Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
        }

        [Fact]
        public void SyncValidatorSetByHeightMaxLongHeightFailsWith404()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var exception = Assert.Throws<CosmosHttpException>(() =>
                client.TendermintRpc.GetValidatorSetByHeight(long.MaxValue));
            Assert.Equal(HttpStatusCode.NotFound, exception.Response?.StatusCode);
        }
    }
}