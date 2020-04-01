using Newtonsoft.Json;

namespace CosmosApi.Serialization
{
    public interface IConverterFactory
    {
        JsonConverter CreateConverter();
    }
}