using Newtonsoft.Json;

namespace DotnetCoreApuxExample.Api.Models
{
    public class Product
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }
    }
}