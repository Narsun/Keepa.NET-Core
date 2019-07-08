using Keepa.NET_Core.Entities;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class ProductResponse
    {
        [JsonProperty("products")]
        public Product[] Products { get; set; }
    }
}