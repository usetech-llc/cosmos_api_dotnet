using System.Net.Http;

namespace CosmosApi.Callbacks
{
    public class BeforeCall
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public HttpRequestMessage Request { get; set; }

        internal BeforeCall(HttpRequestMessage request)
        {
            Request = request;
        }
    }
}