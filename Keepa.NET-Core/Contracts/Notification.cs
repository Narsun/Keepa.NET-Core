using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class Notification
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("createDate")]
        public int CreateDate { get; set; }

        [JsonProperty("domainId")]
        public int DomainId { get; set; }

        [JsonProperty("notificationDomainId")]
        public int NotificationDomainId { get; set; }

        [JsonProperty("csvType")]
        public int CsvType { get; set; }

        [JsonProperty("trackingNotificationCause")]
        public int TrackingNotificationCause { get; set; }

        [JsonProperty("currentPrices")]
        public int[] CurrentPrices { get; set; }

        [JsonProperty("sentNotificationVia")]
        public bool[] SentNotificationVia { get; set; }

        [JsonProperty("metaData")]
        public string MetaData { get; set; }

        [JsonProperty("trackingListName")]
        public string TrackingListName { get; set; }
    }
}