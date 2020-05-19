using System.Threading.Tasks;
using ExtendedNumerics;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class MintTests : BaseTest
    {
        public MintTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetParamsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var @params = await client
                .Mint
                .GetParamsAsync();
            OutputHelper.WriteLine("Deserialized Mint Params:");
            Dump(@params);
            
            Assert.NotEmpty(@params.Result.MintDenom);
            Assert.True(@params.Result.GoalBonded > 0);
            Assert.True(@params.Result.InflationMax > 0);
            Assert.True(@params.Result.InflationMin > 0);
            Assert.True(@params.Result.InflationRateChange > 0);
            Assert.True(@params.Result.BlocksPerYear > 0);
        }

        [Fact]
        public async Task GetInflationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var inflation = await client
                .Mint
                .GetInflationAsync();
            OutputHelper.WriteLine("Deserialized Inflation:");
            Dump(inflation);
            
            Assert.True(inflation.Result > 0);
        }

        [Fact]
        public async Task GetAnnualProvisionsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var annualProvisions = await client
                .Mint
                .GetAnnualProvisionsAsync();
            OutputHelper.WriteLine("Deserialized Annual Provisions:");
            Dump(annualProvisions);
            
            Assert.True(annualProvisions.Result > 0);
        }
    }
}