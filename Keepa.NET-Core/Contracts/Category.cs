using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class Category
    {
        [JsonProperty("domainId")]
        public int DomainId { get; set; }

        [JsonProperty("catId")]
        public long CatId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("children")]
        public long[] Children { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("highestRank")]
        public int HighestRank { get; set; }

        [JsonProperty("productCount")]
        public int ProductCount { get; set; }
    }
}