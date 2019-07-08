using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class MostRatedSellersResponse : ResponseBase
    {
        [JsonProperty("sellerIdList")]
        public string[] Sellers { get; set; }
    }
}