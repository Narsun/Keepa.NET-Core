using Keepa.NET_Core.Entities;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Dto
{
    public class DealsDto
    {
        [JsonProperty("dr")]
        public Deal[] Deals { get; set; }
        [JsonProperty("drDateIndex")]
        public int[] DateIndex { get; set; }
        [JsonProperty("categoryIds")]
        public long[] CategoryIds { get; set; }
        [JsonProperty("categoryNames")]
        public string[] CategoryNames { get; set; }
        [JsonProperty("cateogryCount")]
        public int[] CategoryCount { get; set; }
    }
}
