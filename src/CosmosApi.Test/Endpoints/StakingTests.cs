using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class StakingTests : BaseTest
    {
        public StakingTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }


        [Fact]
        public async Task AsyncDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = await client
                .Staking
                .GetDelegationsAsync(Configuration.LocalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized into:");
            Dump(delegations);
            
            Assert.NotEmpty(delegations.Result);
            Assert.True(delegations.Result[0].Balance > 0);
            Assert.True(delegations.Result[0].Shares > 0);
        }
        
        [Fact]
        public void SyncDelegationsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var delegations = client
                .Staking
                .GetDelegations(Configuration.LocalDelegator1Address);
            
            OutputHelper.WriteLine("Deserialized into:");
            Dump(delegations);
            
            Assert.NotEmpty(delegations.Result);
            Assert.True(delegations.Result[0].Balance > 0);
            Assert.True(delegations.Result[0].Shares > 0);
        }    
    }
}