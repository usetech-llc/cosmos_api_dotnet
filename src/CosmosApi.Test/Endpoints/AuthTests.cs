using System.Threading.Tasks;
using CosmosApi.Models;
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
        public async Task AsyncGetByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account =
                await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount1Address);

            OutputHelper.WriteLine("Deserialized into");
            Dump(account);

            AssertAccountNotEmpty(account.Result);
        }

        private void AssertAccountNotEmpty(IAccount accountResult)
        {
            var account = Assert.IsType<BaseAccount>(accountResult);
            Assert.NotEmpty(account.Address);
            Assert.NotEmpty(account.Coins);
            Assert.All(account.Coins, CoinNotEmpty);
            Assert.NotEmpty(account.PublicKey.Type);
            Assert.NotEmpty(account.PublicKey.Value);
            Assert.True(account.Sequence > 0);
            Assert.True(account.AccountNumber == 0);
        }

        [Fact]
        public void SyncGetByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account =
                 client.Auth.GetAuthAccountByAddress(Configuration.LocalAccount1Address);

            OutputHelper.WriteLine("Deserialized into");
            Dump(account);

            AssertAccountNotEmpty(account.Result);
        }
    }
}