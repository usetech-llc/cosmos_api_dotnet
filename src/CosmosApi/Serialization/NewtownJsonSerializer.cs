using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http.Configuration;

namespace CosmosApi.Serialization
{
    internal class NewtownJsonSerializer : ISerializer
    {
        private readonly NewtonsoftJsonSerializer _serializer;

        public NewtownJsonSerializer(NewtonsoftJsonSerializer serializer)
        {
            _serializer = serializer;
        }
        
        public string SerializeJson<T>(T value)
        {
            return _serializer.Serialize(value);
        }

        public T DeserializeJson<T>(string value)
        {
            return _serializer.Deserialize<T>(value);
        }

        public HttpContent SerializeJsonHttpContent<T>(T value)
        {
            var json = SerializeJson(value);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<T> DeserializeJson<T>(HttpContent content)
        {
            return _serializer.Deserialize<T>(await content.ReadAsStreamAsync());
        }
    }
}