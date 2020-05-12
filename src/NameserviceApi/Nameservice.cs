using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi;
using CosmosApi.Models;
using NameserviceApi.Models;

namespace NameserviceApi
{
    internal class Nameservice : INameservice
    {
        private readonly ICosmosApiClient _cosmosApiClient;

        public Nameservice(ICosmosApiClient cosmosApiClient)
        {
            _cosmosApiClient = cosmosApiClient;
        }

        public async Task<GasEstimateResponse> PostBuyNameSimulationAsync(BuyNameReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, true);
            request = new BuyNameReq(baseReq, request.Name, request.Amount, request.Buyer);
            var content = _cosmosApiClient.Serializer.SerializeJsonHttpContent(request);
            var response = (await _cosmosApiClient.HttpClient.PostAsync("nameservice/names", content, cancellationToken))
                .EnsureSuccessStatusCode();
            return await _cosmosApiClient.Serializer.DeserializeJson<GasEstimateResponse>(response.Content);
        }

        public async Task<StdTx> PostBuyNameAsync(BuyNameReq request, CancellationToken cancellationToken = default)
        {
            var baseReq = new BaseReqWithSimulate(request.BaseReq, false);
            request = new BuyNameReq(baseReq, request.Name, request.Amount, request.Buyer);
            var content = _cosmosApiClient.Serializer.SerializeJsonHttpContent(request);
            var response = (await _cosmosApiClient.HttpClient.PostAsync("nameservice/names", content, cancellationToken))
                .EnsureSuccessStatusCode();
            return await _cosmosApiClient.Serializer.DeserializeJson<StdTx>(response.Content);
        }

        public async Task<ResponseWithHeight<WhoIs>> GetWhoIs(string name, CancellationToken cancellationToken = default)
        {
            var response = (await _cosmosApiClient.HttpClient.GetAsync($"nameservice/names/{name}/whois"))
                .EnsureSuccessStatusCode();
            return await _cosmosApiClient.Serializer.DeserializeJson<ResponseWithHeight<WhoIs>>(response.Content);
        }
    }
}