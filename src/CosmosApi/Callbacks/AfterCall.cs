using System.Net.Http;

namespace CosmosApi.Callbacks
{
    public class AfterCall
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public HttpRequestMessage Request { get; set; }
        /// <summary>
        /// HttpResponseMessage associated with the call if the call completed, otherwise null.
        /// </summary>
        public HttpResponseMessage? Response { get; set; }

    }
}