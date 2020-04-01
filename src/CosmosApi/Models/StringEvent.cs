using System.Collections.Generic;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class StringEvent
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "attributes")]
        public IList<Attribute> Attributes { get; set; }
    }
}