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
        public async Task AsyncGetBankBalanceByAddress_cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns_Completes()
        {
            using var client = CreateClient();
            var balance =
                await client.Bank.GetBankBalancesByAddressAsync("cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns");

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);
        }

        [Fact]
        public void SyncGetBankBalanceByAddress_cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns_Completes()
        {
            using var client = CreateClient();
            var balance =
                client.Bank.GetBankBalancesByAddress("cosmos1h9ymfm2fxrqgd257dlw5nku3jgqjgpl59sm5ns");

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);
        }
    }
}