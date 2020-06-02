using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class SlashingTests : BaseTest
    {
        public SlashingTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetSingingInfoNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var validators = await client.Staking.GetValidatorsAsync();
            var validator = validators.Result.First();

            var signingInfo = await client.Slashing.GetSigningInfoAsync(validator.ConsPubKey);
            OutputHelper.WriteLine("Deserizalized ValidatorSigningInfo");
            Dump(signingInfo);
            
            Assert.NotEmpty(signingInfo.Result.Address);
        }

        [Fact]
        public async Task GetSigningInfosNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var signingInfos = await client
                .Slashing
                .GetSigningInfosAsync();
            OutputHelper.WriteLine("Deserizalized ValidatorSigningInfos");
            Dump(signingInfos);
            
            Assert.NotEmpty(signingInfos.Result);
            Assert.All(signingInfos.Result, s => Assert.NotEmpty(s.Address));
        }

        [Fact]
        public async Task PostUnjailSimulationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);

            var gasEstimation = await client
                .Slashing
                .PostUnjailSimulationAsync(Configuration.LocalValidator1Address, new UnjailRequest(baseReq));
            OutputHelper.WriteLine("Deserialized GasEstimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostUnjailNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);

            var stdTx = await client
                .Slashing
                .PostUnjailAsync(Configuration.LocalValidator1Address, new UnjailRequest(baseReq));
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(stdTx);

            var unjailMsg = stdTx.Msg.OfType<MsgUnjail>().First();
            Assert.Equal("memo", stdTx.Memo);
            Assert.Equal(Configuration.LocalValidator1Address, unjailMsg.ValidatorAddr);
        }

        [Fact]
        public async Task GetParamsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var slashingParams = await client
                .Slashing
                .GetParametersAsync();
            OutputHelper.WriteLine("Deserialized Slashing Params:");
            Dump(slashingParams);
            
            Assert.True(slashingParams.Result.DowntimeJailDuration > 0);
            Assert.True(slashingParams.Result.MaxEvidenceAge > 0);
            Assert.True(slashingParams.Result.SignedBlocksWindow > 0);
            Assert.True(slashingParams.Result.SlashFractionDowntime > 0);
            Assert.True(slashingParams.Result.MinSignedPerWindow > 0);
            Assert.True(slashingParams.Result.SlashFractionDoubleSign > 0);
        }
    }
}