using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Endpoints;
using CosmosApi.Models;
using CosmosApi.Serialization;

namespace CosmosApi
{
    public interface ICosmosApiClient : IDisposable
    {
        IGaiaREST GaiaRest { get; }
        ITendermintRPC TendermintRpc { get; }
        ITransactions Transactions { get; }
        IAuth Auth { get; }
        IBank Bank { get; }
        IStaking Staking { get; }
        IGovernance Governance { get; }
        
        HttpClient HttpClient { get; }
        ISerializer Serializer { get; }

        /// <summary>
        /// Creates signed transaction and broadcasts it.
        /// </summary>
        /// <param name="chainId"></param>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="coins"></param>
        /// <param name="mode"></param>
        /// <param name="fee"></param>
        /// <param name="privateKey"></param>
        /// <param name="passphrase"></param>
        /// <param name="memo"></param>
        /// <param name="cancellationToken"></param>
        Task<BroadcastTxResult> SendAsync(string chainId, string fromAddress, string toAddress, IList<Coin> coins, BroadcastTxMode mode, StdFee fee, string privateKey, string passphrase, string memo = "", CancellationToken cancellationToken = default);

        Task<BaseReq> CreateBaseReq(string @from, string? memo, IList<Coin>? fees, IList<DecCoin>? gasPrices, string? gas, string? gasAdjustment, CancellationToken cancellationToken = default);
    }
}