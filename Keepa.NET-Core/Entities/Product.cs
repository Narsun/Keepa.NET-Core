using Newtonsoft.Json;

namespace Keepa.NET_Core.Entities
{
    public class Product
    {
        [JsonProperty("productType")]
        public int ProductType { get; set; }

        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("domainId")]
        public int DomainId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("trackingSince")]
        public int TrackingSince { get; set; }

        [JsonProperty("listedSince")]
        public int ListedSince { get; set; }

        [JsonProperty("lastUpdate")]
        public int LastUpdate { get; set; }

        [JsonProperty("lastRatingUpdate")]
        public int LastRatingUpdate { get; set; }

        [JsonProperty("lastPriceChange")]
        public int LastPriceChange { get; set; }

        [JsonProperty("lastEbayUpdate")]
        public int LastEbayUpdate { get; set; }

        [JsonProperty("imagesCSV")]
        public string ImageCsv { get; set; }

        [JsonProperty("rootCategory")]
        public long RootCategory { get; set; }

        [JsonProperty("categories")]
        public long[] Categories { get; set; }

        [JsonProperty("categoryTree")]
        public CategoryTreeEntry[] CategoryTree { get; set; }

        [JsonProperty("parentAsin")]
        public string ParentAsin { get; set; }

        [JsonProperty("variationCSV")]
        public string VariationCsv { get; set; }

        [JsonProperty("frequentlyBoughtTogether")]
        public string[] FrequentlyBoughtTogether { get; set; }

        [JsonProperty("eanList")]
        public string[] EanList { get; set; }

        [JsonProperty("upcList")]
        public string[] UpcList { get; set; }

        [JsonProperty("mpn")]
        public string Mpn { get; set; }

        [JsonProperty("hasReviews")]
        public bool HasReviews { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("productGroup")]
        public string ProductGroup { get; set; }

        [JsonProperty("partNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("binding")]
        public string Binding { get; set; }

        [JsonProperty("numberOfItems")]
        public int NumberOfItems { get; set; }

        [JsonProperty("numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("publicationDate")]
        public int PublicationDate { get; set; }

        [JsonProperty("releaseDate")]
        public int ReleaseDate { get; set; }

        [JsonProperty("languages")]
        public string[][] Languages { get; set; }

        [JsonProperty("studio")]
        public string Studio { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("edition")]
        public string Edition { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        /* unused. bad doc (int cannot be null). no data to compare.
        [JsonProperty("hazardousMaterialType")]
        public object HazardousMaterialType { get; set; }
        */
        [JsonProperty("packageHeight")]
        public int PackageHeight { get; set; }

        [JsonProperty("packageLength")]
        public int PackageLength { get; set; }

        [JsonProperty("packageWidth")]
        public int PackageWidth { get; set; }

        [JsonProperty("packageWeight")]
        public int PackageWeight { get; set; }

        [JsonProperty("packageQuantity")]
        public int PackageQuantity { get; set; }

        [JsonProperty("itemHeight")]
        public int ItemHeight { get; set; }

        [JsonProperty("itemLength")]
        public int ItemLength { get; set; }

        [JsonProperty("itemWidth")]
        public int ItemWidth { get; set; }

        [JsonProperty("itemWeight")]
        public int ItemWeight { get; set; }

        [JsonProperty("availabilityAmazon")]
        public int AvailablilityAmazon { get; set; }

        [JsonProperty("ebayListingIds")]
        public long[] EbayListingIds { get; set; }

        [JsonProperty("isAdultProduct")]
        public bool IsAdultProduct { get; set; }

        [JsonProperty("newPriceIsMAP")]
        public bool NewPriceIsMAP { get; set; }

        [JsonProperty("isEligibleForTradeIn")]
        public bool IsEligibleForTradeIn { get; set; }

        [JsonProperty("isEligibleForSuperSaverShipping")]
        public bool IsEligibleForSuperSaverShipping { get; set; }

        [JsonProperty("fbaFees")]
        public FbaFees FbaFees { get; set; }

        [JsonProperty("variations")]
        public Variation[] Variations { get; set; }

        [JsonProperty("coupon")]
        public int[] Coupon { get; set; }

        [JsonProperty("promotions")]
        public Promotion[] Promotions { get; set; }

        [JsonProperty("stats")]
        public Statistics Stats { get; set; }

        [JsonProperty("offers")]
        public MarketplaceOffer[] Offers { get; set; }

        [JsonProperty("liveOffersOrder")]
        public int[] LiveOffersOrder { get; set; }

        [JsonProperty("buyBoxSellerIdHistory")]
        public string[] BuyBoxSellerIdHistory { get; set; }

        [JsonProperty("isRedirectASIN")]
        public bool IsRedirectAsin { get; set; }

        [JsonProperty("isSNS")]
        public bool IsSns { get; set; }

        [JsonProperty("offersSuccessful")]
        public bool OffersSuccessful { get; set; }

        [JsonProperty("csv")]
        public int[][] Csv { get; set; }
    }
}