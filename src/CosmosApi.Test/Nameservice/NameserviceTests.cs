using System;
using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
using NameserviceApi;
using NameserviceApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Nameservice
{
    public class NameserviceTests : BaseTest
    {
        public NameserviceTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task PostBuyNameSimulationCompletes()
        {
            using var client = ConfigureBuilder(Configuration.LocalNameserviceBaseUrl)
                .RegisterAccountType<Account>("cosmos-sdk/Account")
                .CreateClient();
            var namespaceApi = client.CreateNameservice();
            var baseReq = await client.CreateBaseReq(Configuration.LocalNameserviceOwner1, "", null, null, null, null);
            var req = new BuyNameReq(baseReq, Guid.NewGuid().ToString("N"), "1nametoken", Configuration.LocalNameserviceOwner1);
            OutputHelper.WriteLine("Posting buy new name simulation:");
            OutputHelper.WriteLine(client.Serializer.SerializeJson(req));
            var estimation = await namespaceApi.PostBuyNameSimulationAsync(req);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(estimation);
            
            Assert.True(estimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostBuyNameCompletes()
        {
            using var client = ConfigureBuilder(Configuration.LocalNameserviceBaseUrl)
                .RegisterAccountType<Account>("cosmos-sdk/Account")
                .RegisterMsgType<MsgBuyName>("nameservice/BuyName")
                .CreateClient();
            var namespaceApi = client.CreateNameservice();
            var baseReq = await client.CreateBaseReq(Configuration.LocalNameserviceOwner1, "memo", null, null, null, null);
            var name = Guid.NewGuid().ToString("N");
            var req = new BuyNameReq(baseReq, name, "1nametoken", Configuration.LocalNameserviceOwner1);
            OutputHelper.WriteLine("Posting buy new name simulation:");
            OutputHelper.WriteLine(client.Serializer.SerializeJson(req));
            var stdTx = await namespaceApi.PostBuyNameAsync(req);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(stdTx);
            
            Assert.Equal("memo", stdTx.Memo);
            var msgBuyName = stdTx.Msg.OfType<MsgBuyName>().First();
            Assert.Equal(Configuration.LocalNameserviceOwner1, msgBuyName.Buyer);
            Assert.Equal(name, msgBuyName.Name);
            Assert.NotEmpty(msgBuyName.Bid);
            Assert.All(msgBuyName.Bid, c => Assert.True(c.Amount > 0));
        }

        [Fact]
        public async Task BroadcastBuyNameChangesNameOwner()
        {
            using var client = ConfigureBuilder(Configuration.LocalNameserviceBaseUrl)
                .RegisterAccountType<Account>("cosmos-sdk/Account")
                .RegisterMsgType<MsgBuyName>("nameservice/BuyName")
                .CreateClient();
            var namespaceApi = client.CreateNameservice();
            var baseReq = await client.CreateBaseReq(Configuration.LocalNameserviceOwner1, "memo", null, null, null, null);
            var name = Guid.NewGuid().ToString("N");
            var req = new BuyNameReq(baseReq, name, "1nametoken", Configuration.LocalNameserviceOwner1);
            OutputHelper.WriteLine("Posting buy new name simulation:");
            OutputHelper.WriteLine(client.Serializer.SerializeJson(req));
            var stdTx = await namespaceApi.PostBuyNameAsync(req);

            var signers = new []{ new SignerWithAddress(Configuration.LocalNameserviceOwner1, Configuration.LocalNameserviceOwner1PrivateKey, Configuration.LocalNameserviceOwner1Passphrase) };
            var broadcastResponse = await client.SignAndBroadcastStdTxAsync(stdTx, signers, BroadcastTxMode.Block);
            OutputHelper.WriteLine("Deserialized BreoadcastResponse:");
            Dump(broadcastResponse);

            var whoIs = await namespaceApi.GetWhoIs(name);
            OutputHelper.WriteLine("Deserialized WhoIs:");
            Dump(whoIs);
            
            Assert.Equal(Configuration.LocalNameserviceOwner1, whoIs.Result.Owner, StringComparer.Ordinal);
        }
    }
}