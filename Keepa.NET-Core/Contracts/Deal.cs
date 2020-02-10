using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class Deal
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("rootCat")]
        public long RootCat { get; set; }
        [JsonProperty("categories")]
        public long[] Categories { get; set; }
        [JsonProperty("image")]
        public int[] Image { get; set; }
        [JsonProperty("current")]
        public int[] Current { get; set; }
        [JsonProperty("deltaLast")]
        public int[] DeltaLast { get; set; }
        [JsonProperty("delta")]
        public int[,] Delta { get; set; }
        [JsonProperty("deltaPercent")]
        public int[,] DeltaPercent { get; set; }
        [JsonProperty("avg")]
        public int[,] Avg { get; set; }
        [JsonProperty("creationDate")]
        public int CreationDate { get; set; }
        [JsonProperty("lastUpdate")]
        public int LastUpdate { get; set; }
        [JsonProperty("lightningEnd")]
        public int LightningEnd { get; set; }
        [JsonProperty("flags")]
        public int[] Flags { get; set; }
    }
}
