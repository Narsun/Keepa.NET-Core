using Newtonsoft.Json;

namespace Keepa.NET_Core.Entities
{
    public class MarketplaceOffer
    {
        [JsonProperty("offerId")]
        public int OfferId { get; set; }

        [JsonProperty("lastSeen")]
        public int LastSeen { get; set; }

        [JsonProperty("sellerId")]
        public string SellerId { get; set; }

        [JsonProperty("isPrime")]
        public bool IsPrime { get; set; }

        [JsonProperty("isFBA")]
        public bool IsFBA { get; set; }

        [JsonProperty("isMAP")]
        public bool IsMAP { get; set; }

        [JsonProperty("isShippable")]
        public bool IsShippable { get; set; }

        [JsonProperty("isAddonItem")]
        public bool IsAddonItem { get; set; }

        [JsonProperty("isPreorder")]
        public bool IsPreorder { get; set; }

        [JsonProperty("isWarehouseDeal")]
        public bool IsWarehouseDeal {get; set;}

        [JsonProperty("isScam")]
        public bool IsScam { get; set; }

        [JsonProperty("isAmazon")]
        public bool IsAmazon { get; set; }

        [JsonProperty("isPrimeExcl")]
        public bool IsPriceExcl { get; set; }

        [JsonProperty("condition")]
        public int Condition { get; set; }

        [JsonProperty("conditionComment")]
        public string ConditionComment { get; set; }

        [JsonProperty("offerCSV")]
        public int[] OfferCsv { get; set; }
    }
}