using System.Linq;
using CosmosApi.Extensions;
using Newtonsoft.Json.Linq;

namespace CosmosApi.Serialization
{
    public class JsonSorting
    {
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