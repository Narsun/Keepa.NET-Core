using Newtonsoft.Json;

namespace Keepa.NET_Core.Requests
{
    public class DealRequest
    {
        [JsonProperty("filterErotic")]
        public bool FilterErotic { get; set; }
        [JsonProperty("hasReviews")]
        public bool HasReviews { get; set; }
        [JsonProperty("isFilterEnabled")]
        public bool IsFilterEnable { get; set; }
        [JsonProperty("isRangeEnabled")]
        public bool IsRangeEnable { get; set; }
        [JsonProperty("titleSearch")]
        public string TitleSearch { get; set; }
        [JsonProperty("isOutOfStock")]
        public bool IsOutOfStock { get; set; }
        [JsonProperty("isBackInStock")]
        public bool IsBackInStock { get; set; }
        [JsonProperty("isLowestOffer")]
        public bool IsLowestOffer { get; set; }
        [JsonProperty("isLowest")]
        public bool IsLowest { get; set; }
        [JsonProperty("sortType")]
        public int SortType { get; set; }
        [JsonProperty("minRating")]
        public int MinRating { get; set; }
        [JsonProperty("salesRankRange")]
        public int[] SalesRankRange { get; set; }
        [JsonProperty("deltaLastRange")]
        public int[] DeltaLastRange { get; set; }
        [JsonProperty("deltaPercentRange")]
        public int[] DeltaPercentRange { get; set; }
        [JsonProperty("deltaRange")]
        public int[] DeltaRange { get; set; }
        [JsonProperty("priceTypes")]
        public int[] PriceTypes { get; set; }
        [JsonProperty("includeCategories")]
        public long[] IncludeCategories { get; set; }
        [JsonProperty("excludeCategories")]
        public long[] ExcludeCategories { get; set; }
        [JsonProperty("domainId")]
        public int DomainId { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("currentRange")]
        public int[] CurrentRange { get; set; }
        [JsonProperty("dateRange")]
        public int DateRange { get; set; }
    }
}
