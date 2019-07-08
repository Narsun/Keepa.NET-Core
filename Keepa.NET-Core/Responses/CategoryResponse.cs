using Keepa.NET_Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keepa.NET_Core.Responses
{
    public class CategoryResponse : ResponseBase
    {
        [JsonProperty("categories")]
        public Dictionary<string, Category> Categories { get; set; }
    }
}