using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
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

        [Fact]
        public async Task PostWithdrawRewardsSimulationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var gasEstimation = await client
                .Distribution
                .PostWithdrawRewardsSimulationAsync(new WithdrawRewardsRequest(baseRequest));
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostWithdrawRewardsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var stdTx = await client
                .Distribution
                .PostWithdrawRewardsAsync(new WithdrawRewardsRequest(baseRequest));
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(stdTx);

            CheckStdTx(baseRequest, stdTx);
            var withdrawMsg = stdTx.Msg.OfType<MsgWithdrawDelegatorReward>(); 
            Assert.All(withdrawMsg, w =>
            {
                Assert.Equal(Configuration.LocalDelegator1Address, w.DelegatorAddress);
                Assert.NotEmpty(w.ValidatorAddress);
            });
        }

        [Fact]
        public async Task GetDelegatorRewardsFromValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var rewards = await client
                .Distribution
                .GetDelegatorRewardsAsync(Configuration.LocalDelegator1Address, Configuration.LocalValidatorAddress);

            OutputHelper.WriteLine("Deserialized Rewards:");
            Dump(rewards);
            Assert.NotEmpty(rewards.Result);
            Assert.All(rewards.Result, c => Assert.NotEmpty(c.Denom));
            Assert.All(rewards.Result, c => Assert.True(c.Amount > 0));
        }

        [Fact]
        public async Task PostWithdrawRewardsSimulationFromValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var gasEstimation = await client
                .Distribution
                .PostWithdrawRewardsSimulationAsync(Configuration.LocalValidatorAddress, new WithdrawRewardsRequest(baseRequest));
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }
        
        [Fact]
        public async Task PostWithdrawRewardsFromValidatorNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var stdTx = await client
                .Distribution
                .PostWithdrawRewardsAsync(Configuration.LocalValidatorAddress, new WithdrawRewardsRequest(baseRequest));
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(stdTx);

            CheckStdTx(baseRequest, stdTx);
            var withdrawMsg = stdTx.Msg.OfType<MsgWithdrawDelegatorReward>().First(); 
            Assert.Equal(Configuration.LocalDelegator1Address, withdrawMsg.DelegatorAddress);
            Assert.Equal(Configuration.LocalValidatorAddress, withdrawMsg.ValidatorAddress);
        }

        [Fact]
        public async Task GetWithdrawAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var address = await client
                .Distribution
                .GetWithdrawAddressAsync(Configuration.LocalDelegator1Address);
            OutputHelper.WriteLine("Deserialized Address:");
            Dump(address);
            
            Assert.NotEmpty(address.Result);
        }

        [Fact]
        public async Task PostWithdrawAddressSimulationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var request = new SetWithdrawalAddrRequest(baseRequest, Configuration.GlobalDelegator1Address);
            var gasEstimation = await client
                .Distribution
                .PostWithdrawAddressSimulationAsync(request);
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostWithdrawAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseRequest = await client.CreateBaseReq(Configuration.LocalDelegator1Address, "memo", null, null, null, null);
            var request = new SetWithdrawalAddrRequest(baseRequest, Configuration.GlobalDelegator1Address);
            var stdTx = await client
                .Distribution
                .PostWithdrawAddressAsync(request);
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(stdTx);
            
            CheckStdTx(baseRequest, stdTx);
            var msg = stdTx
                .Msg
                .OfType<MsgSetWithdrawAddress>()
                .First();
            
            Assert.Equal(Configuration.LocalDelegator1Address, msg.DelegatorAddress);
            Assert.Equal(Configuration.GlobalDelegator1Address, msg.WithdrawAddress);
        }

        [Fact]
        public async Task GetValidatorDistributionInfoNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var distributionInfo = await client
                .Distribution
                .GetValidatorDistributionInfoAsync(Configuration.LocalValidatorAddress);
            OutputHelper.WriteLine("Deserialized Distribution Info:");
            Dump(distributionInfo);
            Assert.NotEmpty(distributionInfo.Result.OperatorAddress);
            Assert.NotEmpty(distributionInfo.Result.ValCommission);
            Assert.NotEmpty(distributionInfo.Result.SelfBondRewards);
            Assert.All(distributionInfo.Result.ValCommission, CoinNotEmpty);
            Assert.All(distributionInfo.Result.SelfBondRewards, CoinNotEmpty);
        }
    }
}