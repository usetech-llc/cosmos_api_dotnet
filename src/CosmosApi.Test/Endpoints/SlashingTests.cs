using System.Linq;
using System.Threading.Tasks;
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
    }
}