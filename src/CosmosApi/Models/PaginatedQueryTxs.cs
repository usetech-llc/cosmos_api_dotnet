using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class PaginatedQueryTxs
    {
        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedQueryTxs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedQueryTxs(double? totalCount, double? count, double? pageNumber, double? pageTotal, double? limit, IList<TxQuery> txs)
        {
            TotalCount = totalCount;
            Count = count;
            PageNumber = pageNumber;
            PageTotal = pageTotal;
            Limit = limit;
            Txs = txs;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public double? TotalCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public double? Count { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "page_number")]
        public double? PageNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "page_total")]
        public double? PageTotal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public double? Limit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "txs")]
        public IList<TxQuery> Txs { get; set; } = null!;

    }
}
