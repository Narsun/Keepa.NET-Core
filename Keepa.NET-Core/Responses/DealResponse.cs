using Keepa.NET_Core.Dto;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class DealResponse : ResponseBase
    {
        [JsonProperty("deals")]
        public DealsDto Content { get; set; }
    }
}
