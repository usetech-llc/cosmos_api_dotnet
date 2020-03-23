using Newtonsoft.Json;
using System.Linq;

namespace CosmosApi.Models
{
    public partial class AplicationVersion
    {
        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion(string buildTags = default(string), string clientName = default(string), string commit = default(string), string go = default(string), string name = default(string), string serverName = default(string), string version = default(string))
        {
            BuildTags = buildTags;
            ClientName = clientName;
            Commit = commit;
            Go = go;
            Name = name;
            ServerName = serverName;
            Version = version;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "build_tags")]
        public string BuildTags { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "client_name")]
        public string ClientName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "commit")]
        public string Commit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "go")]
        public string Go { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "server_name")]
        public string ServerName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

    }
}
