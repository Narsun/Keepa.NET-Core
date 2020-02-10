using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class TrackingThresholdValue
    {
        [JsonProperty("thresholdValue")]
        public int ThresholdValue { get; set; }

        [JsonProperty("domain")]
        public int Domain { get; set; }

        [JsonProperty("csvType")]
        public int CsvType { get; set; }

        [JsonProperty("isDrop")]
        public bool IsDrop { get; set; }

        [JsonProperty("minDeltaAbsolute")]
        public int MinDeltaAbsolute { get; set; }

        [JsonProperty("minDeltaPercentage")]
        public int MinDeltaPercentage { get; set; }

        [JsonProperty("deltasAreBetweenNotifications")]
        public bool DeltaAreBetweenNotifications { get; set; }
    }
}
