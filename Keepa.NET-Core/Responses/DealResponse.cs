using Keepa.NET.Entities;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class DealResponse : ResponseBase
    {
        [JsonProperty("deals")]
        public DealsDto Deals { get; set; }
    }
}
