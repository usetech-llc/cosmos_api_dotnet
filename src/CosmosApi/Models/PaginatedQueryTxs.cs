using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class PaginatedQueryTxs
    {
        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedQueryTxs()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PaginatedQueryTxs class.
        /// </summary>
        public PaginatedQueryTxs(double? totalCount = default(double?), double? count = default(double?), double? pageNumber = default(double?), double? pageTotal = default(double?), double? limit = default(double?), IList<TxQuery> txs = default(IList<TxQuery>))
        {
            TotalCount = totalCount;
            Count = count;
            PageNumber = pageNumber;
            PageTotal = pageTotal;
            Limit = limit;
            Txs = txs;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        public IList<TxQuery> Txs { get; set; }

    }
}
