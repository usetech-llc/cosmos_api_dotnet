using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class TransactionsTest : BaseTest
    {
        private const string ExistingHash = "9947060C34824A9899ADF3D2E7183855DBEF952B4EAD0B11DF68D41D7470AC1F";
        
        public TransactionsTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncGetSearchNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var searchResult = await client.Transactions.GetSearchAsync("delegate", null, limit: 2);
            OutputHelper.WriteLine("Deserialized Transactions Search Result:");
            Dump(searchResult);
            
            Assert.Equal(2, searchResult.Limit);
            Assert.Equal(1, searchResult.PageNumber);
            Assert.True(searchResult.Count > 0);
            Assert.True(searchResult.PageTotal > 0);
            Assert.True(searchResult.TotalCount > 0);
            Assert.NotEmpty(searchResult.Txs);
            Assert.All(searchResult.Txs, TxIsDelegateAndNotEmpty);
        }

        [Fact]
        public void SyncGetSearchCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var searchResult = client.Transactions.GetSearch("delegate", null, limit: 2);
            OutputHelper.WriteLine("Deserialized Transactions Search Result:");
            Dump(searchResult);
            
            Assert.Equal(2, searchResult.Limit);
            Assert.Equal(1, searchResult.PageNumber);
            Assert.True(searchResult.Count > 0);
            Assert.True(searchResult.PageTotal > 0);
            Assert.True(searchResult.TotalCount > 0);
            Assert.NotEmpty(searchResult.Txs);
            Assert.All(searchResult.Txs, TxIsDelegateAndNotEmpty);
        }

        [Fact]
        public async Task AsyncGetByHashNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            
            var tx = await client.Transactions.GetByHashAsync(
                ByteArrayExtensions.ParseHexString(ExistingHash));
            OutputHelper.WriteLine("Deserialized into");
            Dump(tx);
            
            TxIsDelegateAndNotEmpty(tx);
        }
        
        
        [Fact]
        public void SyncGetByHashNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var tx = client.Transactions.GetByHash(
                ByteArrayExtensions.ParseHexString(ExistingHash));
            OutputHelper.WriteLine("Deserialized into");
            Dump(tx);

            TxIsDelegateAndNotEmpty(tx);
        }
    }
}