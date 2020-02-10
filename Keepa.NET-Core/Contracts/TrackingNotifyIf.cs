using Newtonsoft.Json;

namespace Keepa.NET_Core.Contracts
{
    public class TrackingNotifyIf
    {
        [JsonProperty("domain")]
        public int Domain { get; set; }

        [JsonProperty("csvType")]
        public int CsvType { get; set; }

        [JsonProperty("notifyIfType")]
        public int NotifyIfType {get; set;}
    }
}