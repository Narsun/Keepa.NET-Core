﻿using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class TrackingCreation
    {
        [JsonProperty("asin")]
        public string Asin { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("expireNotify")]
        public bool ExpireNotify { get; set; }

        [JsonProperty("desiredPricesInMainCurrency")]
        public bool DesiredPricesInMainCurrency { get; set; }

        [JsonProperty("mainDomainId")]
        public int MainDomainId { get; set; }

        [JsonProperty("updateInterval")]
        public int UpdateInterval { get; set; }

        [JsonProperty("metaData")]
        public string MetaData { get; set; }

        [JsonProperty("thresholdValues")]
        public TrackingThresholdValue[] ThresholdValues { get; set; }

        [JsonProperty("notifyIf")]
        public TrackingNotifyIf[] NotifyIf { get; set; }

        [JsonProperty("notificationType")]
        public bool[] NotificationType { get; set; }

        [JsonProperty("individualNotificationInterval")]
        public int IndividualNotoficationInterval { get; set; }
    }
}