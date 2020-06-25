using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CosmosApi.Callbacks;
using CosmosApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test
{
    public class BaseTest: IAsyncLifetime
    {
        public ITestOutputHelper OutputHelper { get; }
        public TestConfiguration Configuration { get; }
        
        public BaseTest(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            Configuration = TestConfiguration.Create();
        }

        public async Task<string> GetChainId(ICosmosApiClient cosmosApiClient)
        {
            return (await cosmosApiClient
                    .GaiaRest
                    .GetNodeInfoAsync())
                .NodeInfo
                .Network;
        }

        public ICosmosApiClient CreateClient(string? baseUrl = default)
        {
            return ConfigureBuilder(baseUrl)
                .CreateClient();
        }

        public ICosmosApiBuilder ConfigureBuilder(string? baseUrl)
        {
            return CreateSilentClient(baseUrl)
                .Configure(s =>
                {
                    s.OnAfterCallAsync = OnAfterCall;
                    s.OnBeforeCallAsync = OnBeforeCall;
                });
        }

        private ICosmosApiBuilder CreateSilentClient(string baseUrl)
        {
            return new CosmosApiBuilder()
                .UseBaseUrl(baseUrl ?? Configuration.LocalBaseUrl)
                .RegisterCosmosSdkTypeConverters();
        }

        private Task OnBeforeCall(BeforeCall beforeCall)
        {
            OutputHelper.WriteLine("Sending http request");
            return WriteRequest(beforeCall.Request);
        }

        private async Task OnAfterCall(AfterCall afterCall)
        {
            OutputHelper.WriteLine($"Sent http request at {afterCall.StartedUtc}");
            await WriteRequest(afterCall.Request);
            if (afterCall.Response != null)
            {
                OutputHelper.WriteLine($"Got response at {afterCall.EndedUtc}");
                await WriteResponse(afterCall.Response);
            }
        }

        private Task WriteResponse(HttpResponseMessage response)
        {
            OutputHelper.WriteLine($"HTTP/{response.Version} {response.StatusCode} {response.ReasonPhrase}");
            WriteHeaders(response.Headers);
            return WriteContent(response.Content);
        }

        private Task WriteRequest(HttpRequestMessage request)
        {
            OutputHelper.WriteLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");
            WriteHeaders(request.Headers);
            return WriteContent(request.Content);
        }

        private async Task WriteContent(HttpContent? content)
        {
            if (content == null)
            {
                OutputHelper.WriteLine("No Content");
            }
            else
            {
                OutputHelper.WriteLine("");
                try
                {
                    var contentString = await content.ReadAsStringAsync();
                    WriteLineCutIfTooLong(contentString, "Content is too long, cutting");
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private void WriteHeaders(HttpHeaders headers)
        {
            foreach (var header in headers)
            {
                OutputHelper.WriteLine($"  >{header.Key}: {string.Join(",", header.Value)}");
            }
        }

        public void Dump(object o)
        {
            var dump = ObjectDumper.Dump(o, DumpStyle.CSharp);
            WriteLineCutIfTooLong(dump, "Object is too big, cutting.");
        }

        public void WriteLineCutIfTooLong(string message, string cutWarning)
        {
            var punchCardLength = 80 * 12;
            if (Configuration.CutLongOutput && message.Length > punchCardLength * 2)
            {
                OutputHelper.WriteLine(cutWarning);
                OutputHelper.WriteLine(message[..(punchCardLength * 2 - 3)] + "...");
            }
            else
            {
                OutputHelper.WriteLine(message);
            }
        }

        protected void CheckStdTx(BaseReq baseRequest, StdTx stdTx)
        {
            Assert.Equal(baseRequest.Memo, stdTx.Memo);
        }

        protected void CoinNotEmpty(DecCoin coin)
        {
            Assert.NotEmpty(coin.Denom);
            Assert.True(coin.Amount > 0);
        }

        protected void CoinNotEmpty(Coin coin)
        {
            Assert.NotEmpty(coin.Denom);
            Assert.True(coin.Amount > 0);
        }
        
        protected void TxIsDelegateAndNotEmpty(TxResponse txResponse)
        {
            Assert.True(txResponse.Height > 0);
            Assert.True(txResponse.GasUsed > 0);
            Assert.True(txResponse.GasWanted > 0);
            Assert.NotEmpty(txResponse.Logs);
            Assert.NotEmpty(txResponse.RawLog);
            Assert.NotEmpty(txResponse.TxHash);

            var stdTx = Assert.IsType<StdTx>(txResponse.Tx);
            Assert.NotEmpty(stdTx.Signatures);
            Assert.All(stdTx.Signatures, s =>
            {
                Assert.NotEmpty(s.Signature);
            });
            if (stdTx.Fee.Gas == 0)
            {
                Assert.NotEmpty(stdTx.Fee.Amount);
                Assert.All(stdTx.Fee.Amount, CoinNotEmpty);
            }

            var delegateMsg = stdTx
                .Msg
                .OfType<MsgDelegate>()
                .First();
            CoinNotEmpty(delegateMsg.Amount);
            Assert.NotEmpty(delegateMsg.DelegatorAddress);
            Assert.NotEmpty(delegateMsg.ValidatorAddress);
        }

        public async Task InitializeAsync()
        {
            var client = CreateSilentClient(Configuration.LocalBaseUrl).CreateClient();
            var proposals = await client.Governance.GetProposalsAsync(depositor: Configuration.LocalAccount1Address);
            if (proposals.Result.Any())
            {
                return;
            }
            
            await CreateDelegateTx(client);
            await CreateUnbondTx(client);
            await CreateSubmitProposal(client);
            await CreateDepositAccount2(client);
            await CreateDepositDelegator1(client);
            await Task.Delay(TimeSpan.FromSeconds(20));
            await CreateVoteNo(client);
            await CreateVoteAbstain(client);
            await CreateVoteYes(client);
        }

        private async Task CreateVoteAbstain(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
                await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null),
                Configuration.LocalDelegator1Address, 
                VoteOption.Abstain));
            await client.SignAndBroadcastStdTxAsync(tx, Delegator1Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateVoteNo(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
                await client.CreateBaseReq(Configuration.LocalAccount2Address, null, null, null, null, null),
                Configuration.LocalAccount2Address, 
                VoteOption.No));
            await client.SignAndBroadcastStdTxAsync(tx, Account2Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateVoteYes(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostVoteAsync(1, new VoteReq(
                await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
                Configuration.LocalAccount1Address, 
                VoteOption.Yes));
            await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateDepositDelegator1(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostDepositAsync(1, new DepositReq(
                await client.CreateBaseReq(Configuration.LocalDelegator1Address, null, null, null, null, null),
                Configuration.LocalDelegator1Address, 
                new [] { new Coin("stake", 2000000)}));
            await client.SignAndBroadcastStdTxAsync(tx, Delegator1Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateDepositAccount2(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostDepositAsync(1, new DepositReq(
                await client.CreateBaseReq(Configuration.LocalAccount2Address, null, null, null, null, null),
                Configuration.LocalAccount2Address, 
                new [] { new Coin("stake", 2000000)}));
            await client.SignAndBroadcastStdTxAsync(tx, Account2Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateSubmitProposal(ICosmosApiClient client)
        {
            var tx = await client.Governance.PostProposalAsync(new PostProposalReq(
                await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
                "Test Proposal Title",
                "Test Proposal Description",
                "Text",
                Configuration.LocalAccount1Address, 
                new [] { new Coin("stake", 7000000)}));
            await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateUnbondTx(ICosmosApiClient client)
        {
            var tx = await client.Staking.PostUnbondingDelegationAsync(new UndelegateRequest(
                await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
                Configuration.LocalAccount1Address, Configuration.LocalValidator1Address, 
                new Coin("stake", 99)));
            await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        }

        private async Task CreateDelegateTx(ICosmosApiClient client)
        {
            var tx = await client.Staking.PostDelegationsAsync(new DelegateRequest(
                await client.CreateBaseReq(Configuration.LocalAccount1Address, null, null, null, null, null),
                Configuration.LocalAccount1Address, Configuration.LocalValidator1Address, 
                new Coin("stake", 9999)));
            await client.SignAndBroadcastStdTxAsync(tx, Account1Signer(), BroadcastTxMode.Block);
        }

        private SignerWithAddress[] Delegator1Signer()
        {
            return new[]
            {
                new SignerWithAddress(Configuration.LocalDelegator1Address, Configuration.LocalDelegator1PrivateKey,
                    Configuration.LocalDelegator1Passphrase),
            };
        }

        private SignerWithAddress[] Account1Signer()
        {
            return new[]
            {
                new SignerWithAddress(Configuration.LocalAccount1Address, Configuration.LocalAccount1PrivateKey,
                    Configuration.LocalAccount1Passphrase),
            };
        }

        private SignerWithAddress[] Account2Signer()
        {
            return new[]
            {
                new SignerWithAddress(Configuration.LocalAccount2Address, Configuration.LocalAccount2PrivateKey,
                    Configuration.LocalAccount2Passphrase),
            };
        }

        public Task DisposeAsync()
        {
            return Task.FromResult(0);
        }
    }
}