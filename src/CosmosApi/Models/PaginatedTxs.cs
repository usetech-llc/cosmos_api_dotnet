using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// SearchTxsResult defines a structure for querying txs pageable.
    /// </summary>
    public class PaginatedTxs
    {
        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedTxs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedTxs(int totalCount, int count, int pageNumber, int pageTotal, int limit, IList<TxResponse> txs)
        {
            TotalCount = totalCount;
            Count = count;
            PageNumber = pageNumber;
            PageTotal = pageTotal;
            Limit = limit;
            Txs = txs;
        }

        /// <summary>
        /// Count of all txs.
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Count of txs in current page.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Index of current page, start from 1.
        /// </summary>
        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Count of total pages.
        /// </summary>
        [JsonProperty(PropertyName = "page_total")]
        public int PageTotal { get; set; }

        /// <summary>
        /// Max count txs per page.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// List of txs in current page.
        /// </summary>
        [JsonProperty(PropertyName = "txs")]
        public IList<TxResponse> Txs { get; set; } = null!;

    }
}
