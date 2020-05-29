using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class BankTests : BaseTest
    {
        public BankTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncGetBankBalanceByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var balance =
                await client.Bank.GetBankBalancesByAddressAsync(Configuration.LocalAccount1Address);

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);
            
            Assert.NotEmpty(balance.Result);
            Assert.All(balance.Result, CoinNotEmpty);
        }

        [Fact]
        public void SyncGetBankBalanceByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var balance =
                client.Bank.GetBankBalancesByAddress(Configuration.LocalAccount1Address);

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);

            Assert.NotEmpty(balance.Result);
            Assert.All(balance.Result, CoinNotEmpty);
        }
    }
}