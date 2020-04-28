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
    }
}