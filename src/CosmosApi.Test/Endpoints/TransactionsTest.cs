using System.Net;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using Xunit;

namespace CosmosApi.Test.Endpoints
{
    public class TransactionsTest : BaseTest
    {
        //[Fact]
        //todo: uncomment when server will stop sending 502.
        public async Task AsyncGetSearchCompletes()
        {
            //For some reasons this method returns 502 way too often.
            while (true)
            {
                try
                {
                    using var client = CreateClient();
                    var searchResult = await client.Transactions.GetSearchAsync("send", null, limit: 2);
                    return;
                }
                catch (CosmosHttpException ex)
                {
                    if (ex.Response?.StatusCode == HttpStatusCode.BadGateway)
                    {
                        continue;
                    }

                    throw;
                }
            }
        }
        
        //[Fact]
        //todo: uncomment when server will stop sending 502.
        public void SyncGetSearchCompletes()
        {
            //For some reasons this method returns 502 way too often.
            while (true)
            {
                try
                {
                    using var client = CreateClient();
                    var searchResult = client.Transactions.GetSearch("send", null);
                    return;
                }
                catch (CosmosHttpException ex)
                {
                    if (ex.Response?.StatusCode == HttpStatusCode.BadGateway)
                    {
                        continue;
                    }

                    throw;
                }
            }
        }

        [Fact]
        public async Task AsyncGetByHashCompletes()
        {
            using var client = CreateClient();
            var tx = await client.Transactions.GetByHashAsync(
                ByteArrayExtensions.ParseHexString("7DCB49D5B4FAE87A5532741816E68EE4222C1DBD66326FBADA55268FA7E760E6"));
        }
        
        
        [Fact]
        public void SyncGetByHashCompletes()
        {
            using var client = CreateClient();
            var tx = client.Transactions.GetByHash(
                ByteArrayExtensions.ParseHexString("7DCB49D5B4FAE87A5532741816E68EE4222C1DBD66326FBADA55268FA7E760E6"));
        }
    }
}