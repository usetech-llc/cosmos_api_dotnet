using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class EvidenceData
    {
        public EvidenceData()
        {
        }
        
        public EvidenceData(object? evidence)
        {
            Evidence = evidence;
        }

        /// <summary>
        /// In v0.37.8 evidence is just object without any fields.
        /// </summary>
        [JsonProperty("evidence")]
        public object? Evidence { get; set; }
    }
}