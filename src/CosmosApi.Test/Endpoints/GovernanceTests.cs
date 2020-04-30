using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CosmosApi.Models;
using ExpectedObjects;
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

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "", null, null, null, null);
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

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "", null, null, null, null);
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

        [Fact]
        public async Task GetProposalWithId1NotEmpty()
        {
            using var client = CreateClient();

            var proposal = await client
                .Governance
                .GetProposalAsync(1);
            
            OutputHelper.WriteLine("Deserialized Proposal:");
            Dump(proposal);
            
            Assert.NotNull(proposal);
            Assert.NotNull(proposal.Result);
            Assert.NotNull(proposal.Result.Content);
            Assert.NotNull(proposal.Result.FinalTallyResult);
            Assert.Equal(1UL, proposal.Result.ProposalId);
        }

        [Fact]
        public async Task GetProposerByProposalIdNotEmpty()
        {
            using var client = CreateClient();

            var proposer = await client
                .Governance
                .GetProposerByProposalIdAsync(23);

            OutputHelper.WriteLine("Deserialized Proposer:");
            Dump(proposer);

            Assert.NotNull(proposer);
            Assert.NotNull(proposer.Result);
            Assert.Equal(23UL, proposer.Result.ProposalId);
            Assert.NotEmpty(proposer.Result.ProposerAddress);
        }

        [Fact]
        public async Task GetDepositsByProposalIdNotEmpty()
        {
            using var client = CreateClient();

            var deposits = await client
                .Governance
                .GetDepositsAsync(23);
            
            OutputHelper.WriteLine("Deserialized Deposits:");
            Dump(deposits);
            
            Assert.All(deposits.Result, d =>
            {
                Assert.Equal(23UL, d.ProposalId);
                Assert.NotEmpty(d.Depositor);
                Assert.All(d.Amount, c =>
                {
                    Assert.True(c.Amount >= 0);
                    Assert.NotEmpty(c.Denom);
                });
            });
        }

        [Fact]
        public async Task PostDepositSimulationNotEmpty()
        {
            using var client = CreateClient();

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "", null, null, null, null);
            var amount = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "uatom"
                }
            };
            var depositReq = new DepositReq(baseReq, Configuration.GlobalDelegator1Address, amount);
            var estimation = await client
                .Governance
                .PostDepositSimulationAsync(23, depositReq);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(estimation);
            
            Assert.True(estimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostDepositNotEmpty()
        {
            using var client = CreateClient();

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "memo", null, null, null, null);
            var amount = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "uatom"
                }
            };
            var depositReq = new DepositReq(baseReq, Configuration.GlobalDelegator1Address, amount);
            var tx = await client
                .Governance
                .PostDepositAsync(23, depositReq);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(tx);
            
            Assert.Equal("memo", tx.Memo);
            var msgDeposit = tx.Msg.OfType<MsgDeposit>().First();
            Assert.Equal(Configuration.GlobalDelegator1Address, msgDeposit.Depositor, StringComparer.Ordinal);
            Assert.Equal(23UL, msgDeposit.ProposalId);
            Assert.Collection(msgDeposit.Amount, c =>
            {
                Assert.Equal(10, c.Amount);
                Assert.Equal("uatom", c.Denom, StringComparer.OrdinalIgnoreCase);
            });
        }

        [Fact]
        public async Task GetDepositReturnsOneDepositFromList()
        {
            using var client = CreateClient();

            var deposits = await client
                .Governance
                .GetDepositsAsync(23);
            var expectedDeposit = deposits.Result.First();

            var deposit = await client
                .Governance
                .GetDepositAsync(23, expectedDeposit.Depositor);
            
            OutputHelper.WriteLine("Deserialized Deposit:");
            Dump(deposit);
            
            expectedDeposit.ToExpectedObject()
                .ShouldMatch(deposit.Result);
        }
    }
}