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

        public Task<ResponseWithHeight<IList<Deposit>>> GetDepositsAsync(ulong proposalId, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "deposits")
                .GetJsonAsync<ResponseWithHeight<IList<Deposit>>>(cancellationToken);
        }

        public ResponseWithHeight<IList<Deposit>> GetDeposits(ulong proposalId)
        {
            return GetDepositsAsync(proposalId)
                .Sync();
        }

        public Task<GasEstimateResponse> PostDepositSimulationAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new DepositReq(baseReq, request.Depositor, request.Amount);

            return _clientGetter()
                .Request("gov", "proposals", proposalId, "deposits")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostDepositSimulation(ulong proposalId, DepositReq request)
        {
            return PostDepositSimulationAsync(proposalId, request)
                .Sync();
        }

        public Task<StdTx> PostDepositAsync(ulong proposalId, DepositReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new DepositReq(baseReq, request.Depositor, request.Amount);

            return _clientGetter()
                .Request("gov", "proposals", proposalId, "deposits")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostDeposit(ulong proposalId, DepositReq request)
        {
            return PostDepositAsync(proposalId, request)
                .Sync();
        }

        public Task<ResponseWithHeight<Deposit>> GetDepositAsync(ulong proposalId, string depositor, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "deposits", depositor)
                .GetJsonAsync<ResponseWithHeight<Deposit>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Deposit> GetDeposit(ulong proposalId, string depositor)
        {
            return GetDepositAsync(proposalId, depositor)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Vote>>> GetVotesAsync(ulong proposalId, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "votes")
                .GetJsonAsync<ResponseWithHeight<IList<Vote>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Vote>> GetVotes(ulong proposalId)
        {
            return GetVotesAsync(proposalId)
                .Sync();
        }

        public Task<GasEstimateResponse> PostVoteSimulationAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new VoteReq(baseReq, request.Voter, request.Option);

            return _clientGetter()
                .Request("gov", "proposals", proposalId, "votes")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostVoteSimulation(ulong proposalId, VoteReq request)
        {
            return PostVoteSimulationAsync(proposalId, request)
                .Sync();
        }

        public Task<StdTx> PostVoteAsync(ulong proposalId, VoteReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new VoteReq(baseReq, request.Voter, request.Option);

            return _clientGetter()
                .Request("gov", "proposals", proposalId, "votes")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostVote(ulong proposalId, VoteReq request)
        {
            return PostVoteAsync(proposalId, request)
                .Sync();
        }

        public Task<ResponseWithHeight<Vote>> GetVoteAsync(ulong proposalId, string voter, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "votes", voter)
                .GetJsonAsync<ResponseWithHeight<Vote>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Vote> GetVote(ulong proposalId, string voter)
        {
            return GetVoteAsync(proposalId, voter)
                .Sync();
        }

        public Task<ResponseWithHeight<TallyResult>> GetTallyAsync(ulong proposalId, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "proposals", proposalId, "tally")
                .GetJsonAsync<ResponseWithHeight<TallyResult>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<TallyResult> GetTally(ulong proposalId)
        {
            return GetTallyAsync(proposalId)
                .Sync();
        }

        public Task<ResponseWithHeight<DepositParams>> GetDepositParamsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "parameters", "deposit")
                .GetJsonAsync<ResponseWithHeight<DepositParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<DepositParams> GetDepositParams()
        {
            return GetDepositParamsAsync()
                .Sync();
        }

        public Task<ResponseWithHeight<TallyParams>> GetTallyParamsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "parameters", "tallying")
                .GetJsonAsync<ResponseWithHeight<TallyParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<TallyParams> GetTallyParams()
        {
            return GetTallyParamsAsync()
                .Sync();
        }

        public Task<ResponseWithHeight<VotingParams>> GetVotingParamsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("gov", "parameters", "voting")
                .GetJsonAsync<ResponseWithHeight<VotingParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<VotingParams> GetVotingParams()
        {
            return GetVotingParamsAsync()
                .Sync();
        }
    }
}