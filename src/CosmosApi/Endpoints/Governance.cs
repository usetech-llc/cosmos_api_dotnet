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

        public Task<GasEstimateResponse> PostProposalSimulationAsync(PostProposalReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new PostProposalReq(baseReq, request.Title, request.Description, request.ProposalType, request.Proposer, request.InitialDeposit);
            return _clientGetter()
                .Request("gov", "proposals")
                .PostJsonAsync(request, cancellationToken)
                .WrapExceptions()
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public Task<GasEstimateResponse> PostProposalSimulationAsync(BaseReq baseReq, string title, string description, string proposer,
            IList<Coin> initialDeposit, Type proposalContentType, CancellationToken cancellationToken = default)
        {
            var request = new PostProposalReq(baseReq, title, description, ProposalContentTypeFromType(proposalContentType), proposer, initialDeposit);
            return PostProposalSimulationAsync(request, cancellationToken);
        }

        private static string ProposalContentTypeFromType(Type proposalContentType)
        {
            var contentSample =
                (IProposalContent) proposalContentType.GetConstructor(Type.EmptyTypes)!.Invoke(Array.Empty<object>());
            return contentSample.GetProposalType();
        }

        public Task<GasEstimateResponse> PostProposalSimulationAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer,
            IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent
        {
            return PostProposalSimulationAsync(baseReq, title, description, proposer, initialDeposit,
                typeof(TContentType), cancellationToken);
        }

        public GasEstimateResponse PostProposalSimulation(PostProposalReq request)
        {
            return PostProposalSimulationAsync(request)
                .Sync();
        }

        public GasEstimateResponse PostProposalSimulation(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit,
            Type proposalContentType)
        {
            return PostProposalSimulationAsync(baseReq, title, description, proposer, initialDeposit, proposalContentType)
                .Sync();
        }

        public GasEstimateResponse PostProposalSimulation<TContentType>(BaseReq baseReq, string title, string description, string proposer,
            IList<Coin> initialDeposit) where TContentType : IProposalContent
        {
            return PostProposalSimulationAsync<TContentType>(baseReq, title, description, proposer, initialDeposit)
                .Sync();
        }

        public Task<StdTx> PostProposalAsync(PostProposalReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new PostProposalReq(baseReq, request.Title, request.Description, request.ProposalType, request.Proposer, request.InitialDeposit);
            
            return _clientGetter()
                .Request("gov", "proposals")
                .PostJsonAsync(request, cancellationToken)
                .WrapExceptions()
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public Task<StdTx> PostProposalAsync(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit,
            Type proposalContentType, CancellationToken cancellationToken = default)
        {
            var request = new PostProposalReq(baseReq, title, description, ProposalContentTypeFromType(proposalContentType), proposer, initialDeposit);

            return PostProposalAsync(request, cancellationToken);
        }

        public Task<StdTx> PostProposalAsync<TContentType>(BaseReq baseReq, string title, string description, string proposer,
            IList<Coin> initialDeposit, CancellationToken cancellationToken = default) where TContentType : IProposalContent
        {
            return PostProposalAsync(baseReq, title, description, proposer, initialDeposit, typeof(TContentType),
                cancellationToken);
        }

        public StdTx PostProposal(PostProposalReq request)
        {
            return PostProposalAsync(request)
                .Sync();
        }

        public StdTx PostProposal(BaseReq baseReq, string title, string description, string proposer, IList<Coin> initialDeposit,
            Type proposalContentType)
        {
            return PostProposalAsync(baseReq, title, description, proposer, initialDeposit, proposalContentType)
                .Sync();
        }

        public StdTx PostProposal<TContentType>(BaseReq baseReq, string title, string description, string proposer,
            IList<Coin> initialDeposit) where TContentType : IProposalContent
        {
            return PostProposalAsync<TContentType>(baseReq, title, description, proposer, initialDeposit)
                .Sync();
        }

        public Task<ResponseWithHeight<Proposal>> GetProposalAsync(ulong id, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", id)
                .GetJsonAsync<ResponseWithHeight<Proposal>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Proposal> GetProposal(ulong id)
        {
            return GetProposalAsync(id)
                .Sync();
        }

        public Task<ResponseWithHeight<Proposer>> GetProposerByProposalIdAsync(ulong proposalId, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "proposer")
                .GetJsonAsync<ResponseWithHeight<Proposer>>(cancellationToken);
        }

        public ResponseWithHeight<Proposer> GetProposerByProposalId(ulong proposalId)
        {
            return GetProposerByProposalIdAsync(proposalId)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Deposit>>> GetDepositsByProposalIdAsync(ulong proposalId, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "deposits")
                .GetJsonAsync<ResponseWithHeight<IList<Deposit>>>(cancellationToken);
        }

        public ResponseWithHeight<IList<Deposit>> GetDepositsByProposalId(ulong proposalId)
        {
            return GetDepositsByProposalIdAsync(proposalId)
                .Sync();
        }
    }
}