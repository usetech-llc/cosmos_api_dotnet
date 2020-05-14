using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class DistributionTests : BaseTest
    {
        public DistributionTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetDelegatorRewardsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var rewards = await client
                .Distribution
                .GetDelegatorRewardsAsync(Configuration.LocalDelegator1Address);
            OutputHelper.WriteLine("Deserizalized Rewards:");
            Dump(rewards);
            
            Assert.NotEmpty(rewards.Result.Total);
            Assert.All(rewards.Result.Total, c => Assert.NotEmpty(c.Denom));
            Assert.All(rewards.Result.Total, c => Assert.True(c.Amount > 0));
            Assert.All(rewards.Result.Rewards, r =>
            {
                Assert.NotEmpty(r.ValidatorAddress);
                Assert.All(r.Reward, c => Assert.NotEmpty(c.Denom));
                Assert.All(r.Reward, c => Assert.True(c.Amount > 0));
            });
        }
    }
}