using System.Numerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class StakingPool
    {
        [JsonProperty("not_bonded_tokens")]
        public BigInteger NotBondedTokens { get; set; }
        [JsonProperty("bonded_tokens")]
        public BigInteger BondedTokens { get; set; }

        public StakingPool()
        {
        }

        public StakingPool(BigInteger notBondedTokens, BigInteger bondedTokens)
        {
            NotBondedTokens = notBondedTokens;
            BondedTokens = bondedTokens;
        }
    }
}