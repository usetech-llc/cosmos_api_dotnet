using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Crypto;
using CosmosApi.Endpoints;
using CosmosApi.Models;
using CosmosApi.Serialization;
using TaskTupleAwaiter;

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
        ISlashing Slashing { get; }
        IDistribution Distribution { get; }
        IMint Mint { get; }
        
        HttpClient HttpClient { get; }
        ISerializer Serializer { get; }
        ICryptoService CryptoService { get; }

        /// <summary>
        /// Creates signed transaction and broadcasts it.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddress"></param>
        /// <param name="coins"></param>
        /// <param name="mode"></param>
        /// <param name="fee"></param>
        /// <param name="privateKey"></param>
        /// <param name="passphrase"></param>
        /// <param name="memo"></param>
        /// <param name="cancellationToken"></param>
        public Task<BroadcastTxResult> SendAsync(string fromAddress, string toAddress, IList<Coin> coins, BroadcastTxMode mode, StdFee fee, string privateKey, string passphrase, string memo = "" , CancellationToken cancellationToken = default)
        {
            var msg = new MsgSend()
            {
                FromAddress = fromAddress,
                ToAddress = toAddress,
                Amount = coins,
            };
            var tx = new StdTx()
            {
                Msg = new List<IMsg>() { msg },
                Memo = memo,
                Fee = fee,
            };

            return SignAndBroadcastStdTxAsync(tx, new[] {new SignerWithAddress(fromAddress, privateKey, passphrase)}, mode, cancellationToken);
        }

        public async Task<BaseReq> CreateBaseReq(string @from, string? memo, IList<Coin>? fees, IList<DecCoin>? gasPrices, string? gas, string? gasAdjustment, CancellationToken cancellationToken = default)
        {
            var chainTask = GaiaRest.GetNodeInfoAsync(cancellationToken);
            var accountTask = Auth.GetAuthAccountByAddressAsync(from, cancellationToken);

            var (nodeInfo, account) = await (chainTask, accountTask);
            
            return new BaseReq(from, memo, nodeInfo.NodeInfo.Network, account.Result.GetAccountNumber(), account.Result.GetSequence(), fees, gasPrices, gas, gasAdjustment);
        }

        public async Task<BroadcastTxResult> SignAndBroadcastStdTxAsync(StdTx tx, IEnumerable<SignerWithAddress> signers, BroadcastTxMode mode = BroadcastTxMode.Async, CancellationToken cancellationToken = default)
        {
            var signersSelector = signers.Select(async s => new Signer((await Auth.GetAuthAccountByAddressAsync(s.Address, cancellationToken)).Result, s.EncodedPrivateKey, s.Passphrase));

            var (nodeInfo, accountSigners) = await (GaiaRest.GetNodeInfoAsync(cancellationToken), Task.WhenAll(signersSelector));
            CryptoService.SignStdTx(tx, accountSigners, nodeInfo.NodeInfo.Network, Serializer);
            return await Transactions.PostBroadcastAsync(new BroadcastTxBody(tx, mode), cancellationToken);
        }
        
    }
}