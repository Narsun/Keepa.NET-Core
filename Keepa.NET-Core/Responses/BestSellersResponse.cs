using Keepa.NET_Core.Entities;
using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class BestSellersResponse : ResponseBase
    {
        [JsonProperty("bestSellersList")]
        public BestSeller BestSellers {get; set;}
    }
}