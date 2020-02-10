using Keepa.NET_Core.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keepa.NET_Core.Responses
{
    public class SellerInfoResponse : ResponseBase
    {
        [JsonProperty("sellers")]
        public Dictionary<string, Seller> Sellers { get; set; }
    }
}