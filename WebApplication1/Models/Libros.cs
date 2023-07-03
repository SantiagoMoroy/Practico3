using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Libros
    {
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        [JsonProperty("totalItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalItems { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }
    }
}
