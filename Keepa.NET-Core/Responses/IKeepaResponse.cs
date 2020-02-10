using Keepa.NET_Core.Contracts;

namespace Keepa.NET_Core.Responses
{
    public interface IKeepaResponse
    {
        public long TimeStamp { get; set; }

        public int TokensLeft { get; set; }

        public int RefillIn { get; set; }

        public int RefillRate { get; set; }

        public decimal TokenFlowReduction { get; set; }

        public int TokensConsumed { get; set; }

        public int ProcessingTimeInMs { get; set; }

        public Error Errors { get; set; }
    }
}
