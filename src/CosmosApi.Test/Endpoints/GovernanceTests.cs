using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class GovernanceTests : BaseTest
    {
        public GovernanceTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetProposalsCompletes()
        {
            using var client = CreateClient();

            var proposals = await client
                .Governance
                .GetProposalsAsync(limit: 5);
            
            OutputHelper.WriteLine("Deserialized Proposals:");
            Dump(proposals);
            
            Assert.True(proposals.Result.Count <= 5);
            Assert.True(proposals.Height > 0);
            foreach (var proposal in proposals.Result)
            {
                Assert.True(proposal.Status != 0);
                Assert.NotNull(proposal.Content);
                Assert.NotNull(proposal.TotalDeposit);
                Assert.NotNull(proposal.FinalTallyResult);
                Assert.True(proposal.ProposalId > 0);
            }
        }

        [Fact]
        public async Task GetProposalsStatusFilterWorks()
        {
            using var client = CreateClient();

            var proposals = await client
                .Governance
                .GetProposalsAsync(status: ProposalStatus.Passed);

            OutputHelper.WriteLine("Deserialized Proposals:");
            Dump(proposals);

            Assert.All(proposals.Result, p => Assert.Equal(ProposalStatus.Passed, p.Status));
        }

        [Fact]
        public async Task PostProposalSimulationTextCompletes()
        {
            using var client = CreateClient();

            var account = await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.GlobalDelegator1Address);

            var baseReq = new BaseReq(Configuration.GlobalDelegator1Address, "", await GetChainId(client), account.Result.GetAccountNumber(), account.Result.GetSequence(), null, null, null, null);
            var initialDeposit = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "uatom"
                }
            };
            var gasEstimation = await client
                .Governance
                .PostProposalSimulationAsync<TextProposal>(baseReq, "title", "description", Configuration.GlobalDelegator1Address, initialDeposit);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostProposalTextNotEmpty()
        {
            using var client = CreateClient();

            var account = await client
                .Auth
                .GetAuthAccountByAddressAsync(Configuration.GlobalDelegator1Address);

            var baseReq = new BaseReq(Configuration.GlobalDelegator1Address, "", await GetChainId(client), account.Result.GetAccountNumber(), account.Result.GetSequence(), null, null, null, null);
            var initialDeposit = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "uatom"
                }
            };
            var stdTx = await client
                .Governance
                .PostProposalAsync<TextProposal>(baseReq, "title", "description", Configuration.GlobalDelegator1Address, initialDeposit);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation");
            Dump(stdTx);
            
            Assert.NotNull(stdTx);
            Assert.NotNull(stdTx.Fee);
            Assert.NotEmpty(stdTx.Msg);
            Assert.All(stdTx.Msg, Assert.NotNull);
            var proposalMsg = stdTx.Msg.OfType<MsgSubmitProposal>().First();
            Assert.Equal(Configuration.GlobalDelegator1Address, proposalMsg.Proposer);
            Assert.Equal("title", ((TextProposal)proposalMsg.Content).Title);
            Assert.Equal("description", ((TextProposal)proposalMsg.Content).Description);
            Assert.Collection(proposalMsg.InitialDeposit, coin =>
            {
                Assert.Equal(10, coin.Amount);
                Assert.Equal("uatom", coin.Denom, StringComparer.OrdinalIgnoreCase);
            });
        }
    }
}