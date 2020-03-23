using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public partial class Pathszp1pesauthAccountsAddressgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Pathszp1pesauthAccountsAddressgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathszp1pesauthAccountsAddressgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Pathszp1pesauthAccountsAddressgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public Pathszp1pesauthAccountsAddressgetresponses200contentapplicationJsonschema(string type = default(string), Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue value = default(Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue))
        {
            Type = type;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public Paths1mk6kstauthAccountsAddressgetresponses200contentapplicationJsonschemapropertiesvalue Value { get; set; }

    }
}
