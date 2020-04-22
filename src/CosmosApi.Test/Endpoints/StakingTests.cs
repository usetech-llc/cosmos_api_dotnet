using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
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
        public async Task AsyncGetDelegationsNotEmpty()
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
        public void SyncGetDelegationsNotEmpty()
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

        [Fact]
        public async Task AsyncPostSimulatedDelegationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.LocalDelegator1Address)).Result.Value;
            
            var baseRequest = new BaseReq(Configuration.LocalDelegator1Address, null, Configuration.LocalChainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));

            var postResult = await client
                .Staking
                .PostDelegationsSimulationAsync(delegateRequest);
            OutputHelper.WriteLine("Deserialized gas estimate:");
            Dump(postResult);
            OutputHelper.WriteLine("");
            
            Assert.NotNull(postResult);
        }

        [Fact]
        public async Task AsyncPostDelegationCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account = (await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.LocalDelegator1Address)).Result.Value;
            
            var baseRequest = new BaseReq(Configuration.LocalDelegator1Address, null, Configuration.LocalChainId, account.GetAccountNumber(), account.GetSequence(), null, null, null, null);
            var delegateRequest = new DelegateRequest(baseRequest, Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress, new Coin("stake", 10));

            var postResult = await client
                .Staking
                .PostDelegationsAsync(delegateRequest);
            OutputHelper.WriteLine("Deserialized tx:");
            Dump(postResult);
            OutputHelper.WriteLine("");
            
            Assert.True(postResult.Value.Msg.Count > 0);
            var msgDelegate = (MsgDelegate)postResult
                .Value
                .Msg
                .First(m => m.Value is MsgDelegate)
                .Value;
            Assert.Equal("stake", msgDelegate.Amount.Denom);
            Assert.Equal(10, msgDelegate.Amount.Amount);
        }
    }
}