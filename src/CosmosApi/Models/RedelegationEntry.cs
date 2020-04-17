using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class RedelegationEntry
    {
        /// <summary>
        /// Initializes a new instance of the RedelegationEntry class.
        /// </summary>
        public RedelegationEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RedelegationEntry class.
        /// </summary>
        public RedelegationEntry(int? creationHeight, int? completionTime, string initialBalance, string balance, string sharesDst)
        {
            CreationHeight = creationHeight;
            CompletionTime = completionTime;
            InitialBalance = initialBalance;
            Balance = balance;
            SharesDst = sharesDst;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "creation_height")]
        public int? CreationHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "completion_time")]
        public int? CompletionTime { get; set; }

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
        [JsonProperty(PropertyName = "shares_dst")]
        public string SharesDst { get; set; } = null!;

    }
}
