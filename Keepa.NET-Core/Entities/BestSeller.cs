using Newtonsoft.Json;

namespace Keepa.NET_Core.Entities
{
    public class BestSeller
    {
        [JsonProperty("domainId")]
        public int DomainId { get; set; }

        [JsonProperty("lastUpdate")]
        public int LastUpdate { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("asinList")]
        public string[] AsinList { get; set; }
    }
}