using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BaseReqWithSimulate : BaseReq
    {
        [JsonProperty("simulate")]
        public bool Simulate { get; set; }

        public BaseReqWithSimulate()
        {
        }

        public BaseReqWithSimulate(string @from, string? memo, string chainId, ulong accountNumber, ulong sequence, IList<Coin>? fees, IList<DecCoin>? gasPrices, string? gas, string? gasAdjustment, bool simulate) : base(@from, memo, chainId, accountNumber, sequence, fees, gasPrices, gas, gasAdjustment)
        {
            Simulate = simulate;
        }

        public BaseReqWithSimulate(BaseReq baseReq, bool simulate) : base(baseReq.From, baseReq.Memo, baseReq.ChainId,
            baseReq.AccountNumber, baseReq.Sequence, baseReq.Fees, baseReq.GasPrices, baseReq.Gas,
            baseReq.GasAdjustment)
        {
            Simulate = simulate;
        }
    }
}