using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

namespace CosmosApi.Endpoints
{
    /// <summary>
    /// Stake module APIs.
    /// </summary>
    public interface IStaking
    {
        /// <summary>
        /// Get all delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr);

        /// <summary>
        /// Submit delegation.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TypeValue<StdTx>> PostDelegationsAsync(DelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit delegation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TypeValue<StdTx> PostDelegations(DelegateRequest request);

        /// <summary>
        /// Submit delegation.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostDelegationsSimulationAsync(DelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit delegation.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostDelegationsSimulation(DelegateRequest request);

        /// <summary>
        /// Query the current delegation between a delegator and a validator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <param name="validatorAddr">Bech32 OperatorAddress of validator</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<Delegation>> GetDelegationByValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query the current delegation between a delegator and a validator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <param name="validatorAddr">Bech32 OperatorAddress of validator</param>
        /// <returns></returns>
        ResponseWithHeight<Delegation> GetDelegationByValidator(string delegatorAddr, string validatorAddr);
        
        /// <summary>
        /// Get all unbonding delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<UnbondingDelegation>>> GetUnbondingDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get all unbonding delegations from a delegator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <returns></returns>
        ResponseWithHeight<IList<UnbondingDelegation>> GetUnbondingDelegations(string delegatorAddr);
        
        /// <summary>
        /// Submit an unbonding delegation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostUnbondingDelegationSimulationAsync(UndelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit an unbonding delegation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GasEstimateResponse PostUnbondingDelegationSimulation(UndelegateRequest request);
        
        /// <summary>
        /// Submit an unbonding delegation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TypeValue<StdTx>> PostUnbondingDelegationAsync(UndelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit an unbonding delegation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TypeValue<StdTx> PostUnbondingDelegation(UndelegateRequest request);
        
        /// <summary>
        /// Query all unbonding delegations between a delegator and a validator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <param name="validatorAddr">Bech32 OperatorAddress of validator</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<UnbondingDelegation>> GetUnbondingDelegationsByValidatorAsync(string delegatorAddr, string validatorAddr, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Query all unbonding delegations between a delegator and a validator.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator</param>
        /// <param name="validatorAddr">Bech32 OperatorAddress of validator</param>
        /// <returns></returns>
        ResponseWithHeight<UnbondingDelegation> GetUnbondingDelegationsByValidator(string delegatorAddr, string validatorAddr);

        /// <summary>
        /// Get all redelegations.
        /// </summary>
        /// <param name="delegator">Bech32 AccAddress of Delegator.</param>
        /// <param name="validatorFrom">Bech32 ValAddress of SrcValidator.</param>
        /// <param name="validatorTo">Bech32 ValAddress of DstValidator.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Redelegation>>> GetRedelegationsAsync(string? delegator = default, string? validatorFrom = default, string? validatorTo = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all redelegations.
        /// </summary>
        /// <param name="delegator">Bech32 AccAddress of Delegator.</param>
        /// <param name="validatorFrom">Bech32 ValAddress of SrcValidator.</param>
        /// <param name="validatorTo">Bech32 ValAddress of DstValidator.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Redelegation>> GetRedelegations(string? delegator = default, string? validatorFrom = default, string? validatorTo = default);

        /// <summary>
        /// Submit a redelegation.
        /// </summary>
        /// <param name="request">The sender and tx information.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GasEstimateResponse> PostRedelegationSimulationAsync(RedelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a redelegation.
        /// </summary>
        /// <param name="request">The sender and tx information.</param>
        /// <returns></returns>
        GasEstimateResponse PostRedelegationSimulation(RedelegateRequest request);

        /// <summary>
        /// Submit a redelegation.
        /// </summary>
        /// <param name="request">The sender and tx information.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TypeValue<StdTx>> PostRedelegationAsync(RedelegateRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submit a redelegation.
        /// </summary>
        /// <param name="request">The sender and tx information.</param>
        /// <returns></returns>
        TypeValue<StdTx> PostRedelegation(RedelegateRequest request);

        /// <summary>
        /// Get all validator candidates. By default it returns only the bonded validators.
        /// </summary>
        /// <param name="status">The validator bond status.</param>
        /// <param name="page">The page number.</param>
        /// <param name="limit">The maximum number of items per page.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Validator>>> GetValidatorsAsync(BondStatus? status = default, int? page = default, int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all validator candidates. By default it returns only the bonded validators.
        /// </summary>
        /// <param name="status">The validator bond status.</param>
        /// <param name="page">The page number.</param>
        /// <param name="limit">The maximum number of items per page.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Validator>> GetValidators(BondStatus? status = default, int? page = default, int? limit = default);

        /// <summary>
        /// Query all validators that a delegator is bonded to.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseWithHeight<IList<Validator>>> GetValidatorsAsync(string delegatorAddr, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query all validators that a delegator is bonded to.
        /// </summary>
        /// <param name="delegatorAddr">Bech32 AccAddress of Delegator.</param>
        /// <returns></returns>
        ResponseWithHeight<IList<Validator>> GetValidators(string delegatorAddr);
    }
}