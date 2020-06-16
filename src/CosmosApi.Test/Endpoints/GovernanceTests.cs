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
        private const ulong ProposalId = 1;
        
        public GovernanceTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task GetProposalsCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var proposals = await client
                .Governance
                .GetProposalsAsync(depositor: Configuration.LocalAccount1Address);
            
            OutputHelper.WriteLine("Deserialized Proposals:");
            Dump(proposals);
            
            Assert.True(proposals.Height > 0);
            Assert.All(proposals.Result, proposal =>
            {
                Assert.True(proposal.Status != 0);
                Assert.NotNull(proposal.Content);
                Assert.NotNull(proposal.TotalDeposit);
                Assert.NotNull(proposal.FinalTallyResult);
                Assert.True(proposal.ProposalId > 0);
            });
        }

        [Fact]
        public async Task GetProposalsStatusFilterWorks()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var proposals = await client
                .Governance
                .GetProposalsAsync(status: ProposalStatus.VotingPeriod);

            OutputHelper.WriteLine("Deserialized Proposals:");
            Dump(proposals);

            Assert.NotEmpty(proposals.Result);
            Assert.All(proposals.Result, p => Assert.Equal(ProposalStatus.VotingPeriod, p.Status));
        }

        [Fact]
        public async Task PostProposalSimulationTextCompletes()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "", null, null, null, null);
            var initialDeposit = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "stake"
                }
            };
            var gasEstimation = await client
                .Governance
                .PostProposalSimulationAsync<TextProposal>(baseReq, "title", "description", Configuration.LocalDelegator1Address, initialDeposit);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation");
            Dump(gasEstimation);
            
            Assert.True(gasEstimation.GasEstimate > 0);
        }

        [Fact]
        public async Task PostProposalTextNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "", null, null, null, null);
            var initialDeposit = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "stake"
                }
            };
            var stdTx = await client
                .Governance
                .PostProposalAsync<TextProposal>(baseReq, "title", "description", Configuration.LocalDelegator1Address, initialDeposit);
            
            OutputHelper.WriteLine("Deserialized Gas Estimation");
            Dump(stdTx);
            
            Assert.NotNull(stdTx);
            Assert.NotNull(stdTx.Fee);
            Assert.NotEmpty(stdTx.Msg);
            Assert.All(stdTx.Msg, Assert.NotNull);
            var proposalMsg = stdTx.Msg.OfType<MsgSubmitProposal>().First();
            Assert.Equal(Configuration.LocalDelegator1Address, proposalMsg.Proposer);
            Assert.Equal("title", ((TextProposal)proposalMsg.Content).Title);
            Assert.Equal("description", ((TextProposal)proposalMsg.Content).Description);
            Assert.Collection(proposalMsg.InitialDeposit, coin =>
            {
                Assert.Equal(10, coin.Amount);
                Assert.Equal("stake", coin.Denom, StringComparer.OrdinalIgnoreCase);
            });
        }

        [Fact]
        public async Task GetProposalWithId1NotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

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
            using var client = CreateClient(Configuration.LocalBaseUrl);

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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var deposits = await client
                .Governance
                .GetDepositsAsync(ProposalId);
            
            OutputHelper.WriteLine("Deserialized Deposits:");
            Dump(deposits);
            
            Assert.All(deposits.Result, d =>
            {
                Assert.Equal(ProposalId, d.ProposalId);
                Assert.NotEmpty(d.Depositor);
                Assert.All(d.Amount, CoinNotEmpty);
            });
        }

        [Fact]
        public async Task PostDepositSimulationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "", null, null, null, null);
            var amount = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "stake"
                }
            };
            var depositReq = new DepositReq(baseReq, Configuration.LocalDelegator1Address, amount);
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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);
            var amount = new List<Coin>()
            {
                new Coin()
                {
                    Amount = 10,
                    Denom = "stake"
                }
            };
            var depositReq = new DepositReq(baseReq, Configuration.LocalAccount1Address, amount);
            var tx = await client
                .Governance
                .PostDepositAsync(ProposalId, depositReq);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(tx);
            
            Assert.Equal("memo", tx.Memo);
            var msgDeposit = tx.Msg.OfType<MsgDeposit>().First();
            Assert.Equal(Configuration.LocalAccount1Address, msgDeposit.Depositor, StringComparer.Ordinal);
            Assert.Equal(ProposalId, msgDeposit.ProposalId);
            Assert.Collection(msgDeposit.Amount, c =>
            {
                Assert.Equal(10, c.Amount);
                Assert.Equal("stake", c.Denom, StringComparer.OrdinalIgnoreCase);
            });
        }

        [Fact]
        public async Task GetDepositReturnsOneDepositFromList()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var votes = await client
                .Governance
                .GetVotesAsync(ProposalId);
            
            OutputHelper.WriteLine("Deserizalized Votes");
            Dump(votes);
            Assert.NotEmpty(votes.Result);
            Assert.All(votes.Result, vote =>
            {
                Assert.NotEqual(VoteOption.Empty, vote.Option);
                Assert.NotEmpty(vote.Voter);
                Assert.Equal(ProposalId, vote.ProposalId);
            });
        }

        [Fact]
        public async Task PostVoteSimulationNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "", null, null, null, null);
            var voteReq = new VoteReq(baseReq, Configuration.LocalAccount1Address, VoteOption.Yes);

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
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var baseReq = await client.CreateBaseReq(Configuration.LocalAccount1Address, "memo", null, null, null, null);
            var voteReq = new VoteReq(baseReq, Configuration.LocalAccount1Address, VoteOption.Yes);

            var tx = await client
                .Governance
                .PostVoteAsync(ProposalId, voteReq);
            
            OutputHelper.WriteLine("Deserialized StdTx:");
            Dump(tx);

            Assert.Equal("memo", tx.Memo);
            var msg = tx.Msg.OfType<MsgVote>().First();
            Assert.Equal(VoteOption.Yes, msg.Option);
            Assert.Equal(Configuration.LocalAccount1Address, msg.Voter);
            Assert.Equal(ProposalId, msg.ProposalId);
        }

        //[Fact]
        // Faulty test due to https://github.com/cosmos/cosmos-sdk/issues/6302
        public async Task GetVoteReturnsOneFromTotalList()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

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

        [Fact]
        public async Task GetTallyNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var tally = await client
                .Governance
                .GetTallyAsync(ProposalId);
            
            OutputHelper.WriteLine("Deserialized Tally:");
            Dump(tally);
            Assert.True(tally.Result.Yes > 0);            
        }

        [Fact]
        public async Task GetDepositParamsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var depositParams = await client
                .Governance
                .GetDepositParamsAsync();
            
            OutputHelper.WriteLine("Deserialized Deposit Params:");
            Dump(depositParams);
            
            Assert.True(depositParams.Result.MaxDepositPeriod > 0);
            Assert.True(depositParams.Result.MinDeposit![0].Amount > 0);
            Assert.NotEmpty(depositParams.Result.MinDeposit[0].Denom);
        }

        [Fact]
        public async Task GetTallyParamsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var tallyParams = await client
                .Governance
                .GetTallyParamsAsync();
            
            OutputHelper.WriteLine("Deserialized Tally Params:");
            Dump(tallyParams);
            
            Assert.True(tallyParams.Result.Quorum > 0);
            Assert.True(tallyParams.Result.Threshold > 0);
            Assert.True(tallyParams.Result.Veto > 0);
            
        }

        [Fact]
        public async Task GetVotingParamsNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);

            var votingParams = await client
                .Governance
                .GetVotingParamsAsync();
            
            OutputHelper.WriteLine("Deserialized Voting Params:");
            Dump(votingParams);
            
            Assert.True(votingParams.Result.VotingPeriod > 0);
        }
    }
}