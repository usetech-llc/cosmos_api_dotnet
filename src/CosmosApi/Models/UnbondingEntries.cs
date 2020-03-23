using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class UnbondingEntries
    {
        /// <summary>
        /// Initializes a new instance of the UnbondingEntries class.
        /// </summary>
        public UnbondingEntries()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UnbondingEntries class.
        /// </summary>
        public UnbondingEntries(string initialBalance = default(string), string balance = default(string), string creationHeight = default(string), string minTime = default(string))
        {
            InitialBalance = initialBalance;
            Balance = balance;
            CreationHeight = creationHeight;
            MinTime = minTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        [JsonProperty(PropertyName = "creation_height")]
        public string CreationHeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "min_time")]
        public string MinTime { get; set; }

    }
}
