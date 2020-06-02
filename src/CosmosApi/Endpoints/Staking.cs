using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class Staking : IStaking
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Staking(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "delegations")
                .GetJsonAsync<ResponseWithHeight<IList<Delegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr)
        {
            return GetDelegationsAsync(delegatorAddr)
                .Sync();
        }

        public Task<StdTx> PostDelegationsAsync(DelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseRequest = new BaseReqWithSimulate(request.BaseReq, false);
            request = new DelegateRequest(baseRequest, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "delegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostDelegations(DelegateRequest request)
        {
            return PostDelegationsAsync(request)
                .Sync();
        }

        public Task<GasEstimateResponse> PostDelegationsSimulationAsync(DelegateRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseRequest = new BaseReqWithSimulate(request.BaseReq, true);
            request = new DelegateRequest(baseRequest, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "delegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostDelegationsSimulation(DelegateRequest request)
        {
            return PostDelegationsSimulationAsync(request)
                .Sync();
        }

        public Task<ResponseWithHeight<Delegation>> GetDelegationByValidatorAsync(string delegatorAddr, string validatorAddr,
            CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "delegations", validatorAddr)
                .GetJsonAsync<ResponseWithHeight<Delegation>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Delegation> GetDelegationByValidator(string delegatorAddr, string validatorAddr)
        {
            return GetDelegationByValidatorAsync(delegatorAddr, validatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<UnbondingDelegation>>> GetUnbondingDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "unbonding_delegations")
                .GetJsonAsync<ResponseWithHeight<IList<UnbondingDelegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<UnbondingDelegation>> GetUnbondingDelegations(string delegatorAddr)
        {
            return GetUnbondingDelegationsAsync(delegatorAddr)
                .Sync();
        }

        public Task<GasEstimateResponse> PostUnbondingDelegationSimulationAsync(UndelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new UndelegateRequest(baseReq, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "unbonding_delegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostUnbondingDelegationSimulation(UndelegateRequest request)
        {
            return PostUnbondingDelegationSimulationAsync(request)
                .Sync();
        }

        public Task<StdTx> PostUnbondingDelegationAsync(UndelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new UndelegateRequest(baseReq, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "unbonding_delegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostUnbondingDelegation(UndelegateRequest request)
        {
            return PostUnbondingDelegationAsync(request)
                .Sync();
        }

        public Task<ResponseWithHeight<UnbondingDelegation>> GetUnbondingDelegationsByValidatorAsync(string delegatorAddr, string validatorAddr,
            CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "unbonding_delegations", validatorAddr)
                .GetJsonAsync<ResponseWithHeight<UnbondingDelegation>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<UnbondingDelegation> GetUnbondingDelegationsByValidator(string delegatorAddr, string validatorAddr)
        {
            return GetUnbondingDelegationsByValidatorAsync(delegatorAddr, validatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Redelegation>>> GetRedelegationsAsync(string? delegator = default, string? validatorFrom = default, string? validatorTo = default,
            CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "redelegations")
                .SetQueryParam("delegator", delegator)
                .SetQueryParam("validator_from", validatorFrom)
                .SetQueryParam("validator_to", validatorTo)
                .GetJsonAsync<ResponseWithHeight<IList<Redelegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Redelegation>> GetRedelegations(string? delegator = default, string? validatorFrom = default,
            string? validatorTo = default)
        {
            return GetRedelegationsAsync(delegator, validatorFrom, validatorTo)
                .Sync();
        }

        public Task<GasEstimateResponse> PostRedelegationSimulationAsync(RedelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new RedelegateRequest(baseReq, request.DelegatorAddress, request.ValidatorSrcAddress, request.ValidatorDstAddress, request.Amount);

            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "redelegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostRedelegationSimulation(RedelegateRequest request)
        {
            return PostRedelegationSimulationAsync(request)
                .Sync();
        }

        public Task<StdTx> PostRedelegationAsync(RedelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new RedelegateRequest(baseReq, request.DelegatorAddress, request.ValidatorSrcAddress, request.ValidatorDstAddress, request.Amount);

            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "redelegations")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<StdTx>()
                .WrapExceptions();
        }

        public StdTx PostRedelegation(RedelegateRequest request)
        {
            return PostRedelegationAsync(request)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Validator>>> GetValidatorsAsync(BondStatus? status = default, int? page = default, int? limit = default,
            CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "validators")
                .SetQueryParam("status", status?.ToString())
                .SetQueryParam("page", page)
                .SetQueryParam("limit", limit)
                .GetJsonAsync<ResponseWithHeight<IList<Validator>>>(cancellationToken)
                .WrapExceptions();

        }

        public ResponseWithHeight<IList<Validator>> GetValidators(BondStatus? status = default, int? page = default, int? limit = default)
        {
            return GetValidatorsAsync(status, page, limit)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Validator>>> GetValidatorsAsync(string delegatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "validators")
                .GetJsonAsync<ResponseWithHeight<IList<Validator>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Validator>> GetValidators(string delegatorAddr)
        {
            return GetValidatorsAsync(delegatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<Validator>> GetValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "validators", validatorAddr)
                .GetJsonAsync<ResponseWithHeight<Validator>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Validator> GetValidator(string delegatorAddr, string validatorAddr)
        {
            return GetValidatorAsync(delegatorAddr, validatorAddr)
                .Sync();
        }

        public Task<IList<PaginatedTxs>> GetTransactionsAsync(string delegatorAddr, IList<DelegatingTxType>? txTypes = default,
            CancellationToken cancellationToken = default)
        {
            if (txTypes == null || txTypes.Count <= 0)
            {
                txTypes = (DelegatingTxType[]) Enum.GetValues(typeof(DelegatingTxType));
            }

            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "txs")
                .SetQueryParam("type",  string.Join("+", txTypes.Select(type => type.EnumMember())), true)
                .GetJsonAsync<IList<PaginatedTxs>>(cancellationToken)
                .WrapExceptions();
        }

        public IList<PaginatedTxs> GetTransactions(string delegatorAddr, IList<DelegatingTxType>? txTypes = default)
        {
            return GetTransactionsAsync(delegatorAddr, txTypes)
                .Sync();
        }

        public Task<ResponseWithHeight<Validator>> GetValidatorAsync(string validatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "validators", validatorAddr)
                .GetJsonAsync<ResponseWithHeight<Validator>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<Validator> GetValidator(string validatorAddr)
        {
            return GetValidatorAsync(validatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsByValidatorAsync(string validatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "validators", validatorAddr, "delegations")
                .GetJsonAsync<ResponseWithHeight<IList<Delegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Delegation>> GetDelegationsByValidator(string validatorAddr)
        {
            return GetDelegationsByValidatorAsync(validatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<IList<UnbondingDelegation>>> GetUnbondingDelegationsByValidatorAsync(string validatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "validators", validatorAddr, "unbonding_delegations")
                .GetJsonAsync<ResponseWithHeight<IList<UnbondingDelegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<UnbondingDelegation>> GetUnbondingDelegationsByValidator(string validatorAddr)
        {
            return GetUnbondingDelegationsByValidatorAsync(validatorAddr)
                .Sync();
        }

        public Task<ResponseWithHeight<StakingPool>> GetStakingPoolAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "pool")
                .GetJsonAsync<ResponseWithHeight<StakingPool>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<StakingPool> GetStakingPool()
        {
            return GetStakingPoolAsync()
                .Sync();
        }

        public Task<ResponseWithHeight<StakingParams>> GetStakingParamsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "parameters")
                .GetJsonAsync<ResponseWithHeight<StakingParams>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<StakingParams> GetStakingParams()
        {
            return GetStakingParamsAsync()
                .Sync();
        }
    }
    
}