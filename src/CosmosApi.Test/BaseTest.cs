using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CosmosApi.Callbacks;
using CosmosApi.Models;
using Xunit.Abstractions;

namespace CosmosApi.Test
{
    public class BaseTest
    {
        public ITestOutputHelper OutputHelper { get; }
        public TestConfiguration Configuration { get; }
        
        public BaseTest(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            Configuration = TestConfiguration.Create();
        }

        public async Task<string> GetChainId(ICosmosApiClient cosmosApiClient)
        {
            return (await cosmosApiClient
                    .GaiaRest
                    .GetNodeInfoAsync())
                .NodeInfo
                .Network;
        }

        public CosmosApiClient CreateClient(string? baseUrl = default)
        {
            return (new CosmosApiBuilder()
                .UseBaseUrl(baseUrl ?? Configuration.GlobalBaseUrl)
                .Configure(s =>
                {
                    s.OnAfterCallAsync = OnAfterCall;
                    s.OnBeforeCallAsync = OnBeforeCall;
                })
                .RegisterCosmosSdkTypeConverters()
                .CreateClient() as CosmosApiClient)!;
        }

        private Task OnBeforeCall(BeforeCall beforeCall)
        {
            OutputHelper.WriteLine("Sending http request");
            return WriteRequest(beforeCall.Request);
        }

        private async Task OnAfterCall(AfterCall afterCall)
        {
            OutputHelper.WriteLine($"Sent http request at {afterCall.StartedUtc}");
            await WriteRequest(afterCall.Request);
            if (afterCall.Response != null)
            {
                OutputHelper.WriteLine($"Got response at {afterCall.EndedUtc}");
                await WriteResponse(afterCall.Response);
            }
        }

        private Task WriteResponse(HttpResponseMessage response)
        {
            OutputHelper.WriteLine($"HTTP/{response.Version} {response.StatusCode} {response.ReasonPhrase}");
            WriteHeaders(response.Headers);
            return WriteContent(response.Content);
        }

        private Task WriteRequest(HttpRequestMessage request)
        {
            OutputHelper.WriteLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");
            WriteHeaders(request.Headers);
            return WriteContent(request.Content);
        }

        private async Task WriteContent(HttpContent? content)
        {
            if (content == null)
            {
                OutputHelper.WriteLine("No Content");
            }
            else
            {
                OutputHelper.WriteLine("");
                try
                {
                    var contentString = await content.ReadAsStringAsync();
                    WriteLineCutIfTooLong(contentString, "Content is too long, cutting");
                }
                catch (ObjectDisposedException)
                {
                    OutputHelper.WriteLine("Failed to read stream, it's already disposed.");
                }
            }
        }

        private void WriteHeaders(HttpHeaders headers)
        {
            foreach (var header in headers)
            {
                OutputHelper.WriteLine($"  >{header.Key}: {string.Join(",", header.Value)}");
            }
        }

        public void Dump(object o)
        {
            var dump = ObjectDumper.Dump(o, DumpStyle.CSharp);
            WriteLineCutIfTooLong(dump, "Object is too big, cutting.");
        }

        public void WriteLineCutIfTooLong(string message, string cutWarning)
        {
            var punchCardLength = 80 * 12;
            if (message.Length > punchCardLength * 4)
            {
                OutputHelper.WriteLine(cutWarning);
                OutputHelper.WriteLine(message[..(punchCardLength * 4 - 3)] + "...");
            }
            else
            {
                OutputHelper.WriteLine(message);
            }
        }
    }
}