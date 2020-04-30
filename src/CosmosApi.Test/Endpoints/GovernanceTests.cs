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
        private const ulong ProposalId = 23;
        
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
                .GetProposerByProposalIdAsync(ProposalId);

            OutputHelper.WriteLine("Deserialized Proposer:");
            Dump(proposer);

            Assert.NotNull(proposer);
            Assert.NotNull(proposer.Result);
            Assert.Equal(ProposalId, proposer.Result.ProposalId);
            Assert.NotEmpty(proposer.Result.ProposerAddress);
        }

        [Fact]
        public async Task GetDepositsByProposalIdNotEmpty()
        {
            using var client = CreateClient();

            var deposits = await client
                .Governance
                .GetDepositsAsync(ProposalId);
            
            OutputHelper.WriteLine("Deserialized Deposits:");
            Dump(deposits);
            
            Assert.All(deposits.Result, d =>
            {
                Assert.Equal(ProposalId, d.ProposalId);
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
                .PostDepositSimulationAsync(ProposalId, depositReq);
            
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
                .PostDepositAsync(ProposalId, depositReq);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(tx);
            
            Assert.Equal("memo", tx.Memo);
            var msgDeposit = tx.Msg.OfType<MsgDeposit>().First();
            Assert.Equal(Configuration.GlobalDelegator1Address, msgDeposit.Depositor, StringComparer.Ordinal);
            Assert.Equal(ProposalId, msgDeposit.ProposalId);
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
                .GetDepositsAsync(ProposalId);
            var expectedDeposit = deposits.Result.First();

            var deposit = await client
                .Governance
                .GetDepositAsync(ProposalId, expectedDeposit.Depositor);
            
            OutputHelper.WriteLine("Deserialized Deposit:");
            Dump(deposit);
            
            expectedDeposit.ToExpectedObject()
                .ShouldMatch(deposit.Result);
        }

        [Fact]
        public async Task GetVotesNotEmpty()
        {
            using var client = CreateClient();

            var votes = await client
                .Governance
                .GetVotesAsync(ProposalId);
            
            OutputHelper.WriteLine("Deserizalized Votes");
            Dump(votes);
            
            Assert.NotEmpty(votes.Result);
            Assert.All(votes.Result, v =>
            {
                Assert.NotEmpty(v.Voter);
                Assert.Equal(ProposalId, v.ProposalId);
                Assert.NotEqual(VoteOption.Empty, v.Option);
            });
        }

        [Fact]
        public async Task PostVoteSimulationNotEmpty()
        {
            using var client = CreateClient();

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "", null, null, null, null);
            var voteReq = new VoteReq(baseReq, Configuration.GlobalDelegator1Address, VoteOption.Yes);

            var gasEstimation = await client
                .Governance
                .PostVoteSimulationAsync(ProposalId, voteReq);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation:");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }
 
        [Fact]
        public async Task PostVoteNotEmpty()
        {
            using var client = CreateClient();

            var baseReq = await client.CreateBaseReq(Configuration.GlobalDelegator1Address, "memo", null, null, null, null);
            var voteReq = new VoteReq(baseReq, Configuration.GlobalDelegator1Address, VoteOption.Yes);

            var tx = await client
                .Governance
                .PostVoteAsync(ProposalId, voteReq);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(tx);

            Assert.Equal("memo", tx.Memo);
            var msg = tx.Msg.OfType<MsgVote>().First();
            Assert.Equal(VoteOption.Yes, msg.Option);
            Assert.Equal(Configuration.GlobalDelegator1Address, msg.Voter);
            Assert.Equal(ProposalId, msg.ProposalId);
        }

        //[Fact]
        //Some internal gaia issues. It awlays returns
        ///{
        ///    "error": "'' is not a valid vote option"
        ///}
        /// And that is because it cannot deserialize result from its internal call.
        public async Task GetVoteReturnsOneFromTotalList()
        {
            using var client = CreateClient();

            var votes = await client
                .Governance
                .GetVotesAsync(ProposalId);

            var expectedVote = votes.Result.Last();

            var vote = await client
                .Governance
                .GetVoteAsync(ProposalId, expectedVote.Voter);
            
            OutputHelper.WriteLine("Deserialized Vote");
            Dump(vote);
            
            expectedVote.ToExpectedObject()
                .ShouldMatch(vote.Result);
        }
    }
}