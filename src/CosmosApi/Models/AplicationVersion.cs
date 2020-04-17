using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class AplicationVersion
    {
        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion(string buildTags, string clientName, string commit, string go, string name, string serverName, string version)
        {
            BuildTags = buildTags;
            ClientName = clientName;
            Commit = commit;
            Go = go;
            Name = name;
            ServerName = serverName;
            Version = version;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "build_tags")]
        public string BuildTags { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "client_name")]
        public string ClientName { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "commit")]
        public string Commit { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "go")]
        public string Go { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "server_name")]
        public string ServerName { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; } = null!;

    }
}
