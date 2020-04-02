using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class AuthTests : BaseTest
    {
        public AuthTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncGetByAddress_cosmos16xyempempp92x9hyzz9wrgf94r6j9h5f06pxxv_Completes()
        {
            using var client = CreateClient();

            var account =
                await client.Auth.GetAuthAccountByAddressAsync("cosmos16xyempempp92x9hyzz9wrgf94r6j9h5f06pxxv");

            OutputHelper.WriteLine("Deserialized into");
            Dump(account);
        }

        [Fact]
        public void SyncGetByAddress_cosmos16xyempempp92x9hyzz9wrgf94r6j9h5f06pxxv_Completes()
        {
            using var client = CreateClient();

            var account =
                 client.Auth.GetAuthAccountByAddress("cosmos16xyempempp92x9hyzz9wrgf94r6j9h5f06pxxv");

            OutputHelper.WriteLine("Deserialized into");
            Dump(account);
        }
    }
}