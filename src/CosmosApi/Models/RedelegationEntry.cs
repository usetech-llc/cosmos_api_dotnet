using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class RedelegationEntry
    {
        /// <summary>
        /// Initializes a new instance of the RedelegationEntry class.
        /// </summary>
        public RedelegationEntry()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedelegationEntry class.
        /// </summary>
        public RedelegationEntry(int? creationHeight = default(int?), int? completionTime = default(int?), string initialBalance = default(string), string balance = default(string), string sharesDst = default(string))
        {
            CreationHeight = creationHeight;
            CompletionTime = completionTime;
            InitialBalance = initialBalance;
            Balance = balance;
            SharesDst = sharesDst;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        public string InitialBalance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shares_dst")]
        public string SharesDst { get; set; }

    }
}
