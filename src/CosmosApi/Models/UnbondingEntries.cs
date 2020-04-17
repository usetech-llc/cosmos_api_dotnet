using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class UnbondingEntries
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingEntries class.
        /// </summary>
        public UnbondingEntries()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingEntries class.
        /// </summary>
        public UnbondingEntries(string initialBalance, string balance, string creationHeight, string minTime)
        {
            InitialBalance = initialBalance;
            Balance = balance;
            CreationHeight = creationHeight;
            MinTime = minTime;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "initial_balance")]
        public string InitialBalance { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "creation_height")]
        public string CreationHeight { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "min_time")]
        public string MinTime { get; set; } = null!;

    }
}
