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
    }
}