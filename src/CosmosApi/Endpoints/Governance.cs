using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class Governance : IGovernance
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Governance(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<IList<Proposal>>> GetProposalsAsync(string? voter = default, string? depositor = default, ProposalStatus? status = default,
            ulong? limit = default, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals")
                .SetQueryParam("voter", voter)
                .SetQueryParam("depositor", depositor)
                .SetQueryParam("status", status)
                .SetQueryParam("limit", limit)
                .GetJsonAsync<ResponseWithHeight<IList<Proposal>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Proposal>> GetProposals(string? voter = default, string? depositor = default, ProposalStatus? status = default,
            ulong? limit = default)
        {
            return GetProposalsAsync(voter, depositor, status, limit)
                .Sync();
        }
    }
}