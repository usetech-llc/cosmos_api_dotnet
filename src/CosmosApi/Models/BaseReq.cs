using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BaseReq
    {
        [JsonProperty("from")]
        public string From { get; set; } = null!;
        [JsonProperty("memo")]
        public string? Memo { get; set; }
        [JsonProperty("chain_id")]
        public string ChainId { get; set; } = null!;
        [JsonProperty("account_number")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong AccountNumber { get; set; }
        [JsonProperty("sequence")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong Sequence { get; set; }
        [JsonProperty("fees")]
        public IList<Coin>? Fees { get; set; }
        [JsonProperty("gas_prices")]
        public IList<DecCoin>? GasPrices { get; set; }
        [JsonProperty("gas")]
        public string? Gas { get; set; }
        [JsonProperty("gas_adjustment")]
        public string? GasAdjustment { get; set; }

        public BaseReq()
        {
        }

        public BaseReq(string @from, string? memo, string chainId, ulong accountNumber, ulong sequence, IList<Coin>? fees, IList<DecCoin>? gasPrices, string? gas, string? gasAdjustment)
        {
            From = @from;
            Memo = memo;
            ChainId = chainId;
            AccountNumber = accountNumber;
            Sequence = sequence;
            Fees = fees;
            GasPrices = gasPrices;
            Gas = gas;
            GasAdjustment = gasAdjustment;
        }
    }
}