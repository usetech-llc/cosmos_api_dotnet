using System.Net.Http;
using System.Threading.Tasks;

namespace CosmosApi.Serialization
{
    public interface ISerializer
    {
        string SerializeJson<T>(T value);
        T DeserializeJson<T>(string value);
        HttpContent SerializeJsonHttpContent<T>(T value);
        Task<T> DeserializeJson<T>(HttpContent content);
        string SerializeSortedAndCompact<T>(T value);
    }
}