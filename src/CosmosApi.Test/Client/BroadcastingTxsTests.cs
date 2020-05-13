using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CosmosApi.Models;
using CosmosApi.Test.Endpoints;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Client
{
    public class ClientTests : BaseTest
    {
        public ClientTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncCreateTransactionTransferCoins()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var account1BeforeTransaction = ((await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount1Address)).Result as BaseAccount)!;
            Assert.NotNull(account1BeforeTransaction);
            var account2BeforeTransaction = ((await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount2Address)).Result as BaseAccount)!;
            Assert.NotNull(account2BeforeTransaction);

            var denom = account1BeforeTransaction.Coins[0].Denom;
            var amount = 10;
            var coinsToSend = new List<Coin>()
            {
                new Coin(denom, amount)
            };
            var memo = Guid.NewGuid().ToString("D");
            var fee = new StdFee()
            {
                Amount = new List<Coin>(),
                Gas = 300000,
            };
            var result = await ((ICosmosApiClient)client).SendAsync( Configuration.LocalAccount1Address, Configuration.LocalAccount2Address, coinsToSend, BroadcastTxMode.Block, fee, Configuration.LocalAccount1PrivateKey, Configuration.LocalAccount1Passphrase, memo);
            OutputHelper.WriteLine("Deserialized broadcast result");
            Dump(result);
            OutputHelper.WriteLine("");
            Assert.NotNull(result.TxHash);
            Assert.True(result.TxHash.Length > 0);
            Assert.True(result.Logs.All(l => l.Success));
            var account1AfterTransaction =
                ((await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount1Address)).Result as BaseAccount)!;
            var account1CoinsBefore = GetAmount(account1BeforeTransaction, denom);
            var account1CoinsAfter = GetAmount(account1AfterTransaction, denom);
            Assert.Equal(account1CoinsBefore - amount, account1CoinsAfter);
            var account2AfterTransaction =
                ((await client.Auth.GetAuthAccountByAddressAsync(Configuration.LocalAccount2Address)).Result as BaseAccount)!;
            var account2CoinsBefore = GetAmount(account2BeforeTransaction, denom);
            var account2CoinsAfter = GetAmount(account2AfterTransaction, denom);
            Assert.Equal(account2CoinsBefore + amount, account2CoinsAfter);
        }

        private BigInteger GetAmount(BaseAccount account, string denom)
        {
            return account
                .Coins
                .First(c => string.Equals(c.Denom, denom, StringComparison.Ordinal))
                .Amount;   
        }
    }
}