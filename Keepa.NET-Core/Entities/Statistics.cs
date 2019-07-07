using Newtonsoft.Json;

namespace Keepa.NET_Core.Entities
{
    public class Statistics
    {
        [JsonProperty("current")]
        public int[] Current { get; set; }

        [JsonProperty("avg")]
        public int[] Avg { get; set; }

        [JsonProperty("avg30")]
        public int[] Avg30 { get; set; }

        [JsonProperty("avg90")]
        public int[] Avg90 { get; set; }

        [JsonProperty("avg180")]
        public int[] Avg180 { get; set; }

        [JsonProperty("atIntervalStart")]
        public int[] AtIntervalStart { get; set; }

        [JsonProperty("min")]
        public int[][] Min { get; set; }

        [JsonProperty("max")]
        public int[][] Max { get; set; }

        [JsonProperty("minInInterval")]
        public int[][] MinInInterval { get; set; }

        [JsonProperty("maxInInterval")]
        public int[][] MaxInInterval { get; set; }

        [JsonProperty("outOfStockPercentageInInterval")]
        public int[] OutOfStockPercentageInInterval { get; set; }

        [JsonProperty("outOfStockPercentage30")]
        public int[] OutOfStockPercentage30 { get; set; }

        [JsonProperty("outOfStockPercentage90")]
        public int[] OutOfStockPercentage90 { get; set; }

        [JsonProperty("lastOffersUpdate")]
        public int LastOffersUpdate { get; set; }

        [JsonProperty("totalOfferCount")]
        public int TotalOfferCount { get; set; }

        [JsonProperty("lightningDealInfo")]
        public int[] LightningDealInfo { get; set; }

        // the following fields are only set if the offers parameter was used
        [JsonProperty("retrievedOfferCount")]
        public int RetrievedOfferCount { get; set; }

        [JsonProperty("buyBoxPrice")]
        public int BuyBoxPrice { get; set; }

        [JsonProperty("buyBoxShipping")]
        public int BuyBoxShipping { get; set; }

        [JsonProperty("buyBoxIsUnqualified")]
        public bool BuyBoxIsUnqualified { get; set; }

        [JsonProperty("buyBoxIsShippable")]
        public bool BuyBoxIsShippable { get; set; }

        [JsonProperty("buyBoxIsPreorder")]
        public bool BuyBoxIsPreorder { get; set; }

        [JsonProperty("buyBoxIsFBA")]
        public bool BuyBoxIsFBA { get; set; }

        [JsonProperty("buyBoxIsAmazon")]
        public bool BuyBoxIsAmazon { get; set; }

        [JsonProperty("buyBoxIsMAP")]
        public bool BuyBoxIsMAP { get; set; }

        [JsonProperty("buyBoxIsUsed")]
        public bool BuyBoxIsUsed { get; set; }

        [JsonProperty("isAddonItem")]
        public bool IsAddonItem { get; set; }

        [JsonProperty("sellerIdsLowestFBA")]
        public string[] SellerIdsLowestFBA { get; set; }

        [JsonProperty("sellerIdsLowestFBM")]
        public string[] SellerIdsLowestFBM { get; set; }

        [JsonProperty("offerCountFBA")]
        public int OfferCountFBA {get; set;}

        [JsonProperty("offerCountFBM")]
        public int OfferCountFBM { get; set; }
    }
}