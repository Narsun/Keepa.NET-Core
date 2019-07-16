using Keepa.NET_Core.Entities;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class ProductResponse : ResponseBase
    {
        [JsonProperty("products")]
        public Product[] Products { get; set; }
    }
}