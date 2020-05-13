using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CosmosApi.Serialization
{
    internal class NewtownJsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _settings;

        public NewtownJsonSerializer(JsonSerializerSettings settings)
        {
            _settings = settings;
        }
        
        public string SerializeJson<T>(T value)
        {
            return new NewtonsoftJsonSerializer(_settings).Serialize(value);
        }

        public T DeserializeJson<T>(string value)
        {
            return new NewtonsoftJsonSerializer(_settings).Deserialize<T>(value);
        }

        public HttpContent SerializeJsonHttpContent<T>(T value)
        {
            var json = SerializeJson(value);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<T> DeserializeJson<T>(HttpContent content)
        {
            return new NewtonsoftJsonSerializer(_settings).Deserialize<T>(await content.ReadAsStreamAsync());
        }

        public string SerializeSortedAndCompact<T>(T value)
        {
            var jObject = JObject.FromObject(value!, JsonSerializer.Create(_settings));
            SortJson(jObject);
            return jObject.ToString(Formatting.None, _settings.Converters.ToArray());
        }
        
        /// <summary>
        /// Sorts keys inside jObject alphabetically.
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public static void SortJson(JObject jObject)
        {
            var props = jObject.Properties().ToList();
            foreach (var prop in props)
            {
                prop.Remove();
            }

            foreach (var prop in props.OrderBy(p=>p.Name))
            {
                jObject.Add(prop);
                Sort(prop.Value);
            }
        }

        private static void Sort(JToken token)
        {
            switch (token)
            {
                case JObject jObject:
                    SortJson(jObject);
                    break;
                case JArray array:
                    array.ForEach(Sort);
                    break;
                default: 
                    return; 
            }
        }
    }
}