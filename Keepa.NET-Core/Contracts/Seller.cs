using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class Seller
    {
        [JsonProperty("domainId")]
        public int DomainId { get; set; }

        [JsonProperty("trackedSince")]
        public int TrackingSince { get; set; }

        [JsonProperty("lastUpdate")]
        public int LastUpdate { get; set; }

        [JsonProperty("sellerId")]
        public string SellerId { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("isScammer")]
        public bool IsScammer { get; set; }

        [JsonProperty("hasFBA")]
        public bool HasFBA { get; set; }

        [JsonProperty("totalStorefrontAsins")]
        public int[] TotalScoreFrontAsins { get; set; }

        [JsonProperty("csv")]
        public int[][] Csv { get; set; }

        [JsonProperty("asinList")]
        public string[] AsinList { get; set; }

        [JsonProperty("asinListLastSeen")]
        public int[] AsinListLastSeen { get; set; }
    }
}