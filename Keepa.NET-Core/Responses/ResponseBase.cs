using Newtonsoft.Json;

namespace Keepa.NET_Core.Responses
{
    public class ResponseBase
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("tokensLeft")]
        public int TokensLeft { get; set; }

        [JsonProperty("refillIn")]
        public int RefillIn { get; set; }

        [JsonProperty("refillRate")]
        public int RefillRate { get; set; }

        [JsonProperty("tokenFlowReduction")]
        public decimal TokenFlowReduction { get; set; }

        [JsonProperty("tokensConsumed")]
        public int TokensConsumed { get; set; }

        [JsonProperty("processingTimeInMs")]
        public int ProcessingTimeInMs { get; set; }
    }
}