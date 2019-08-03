namespace Keepa.NET_Core.Requests
{
    public class ProductRequest
    {
        public int DomainId { get; set; }
        public string Asin { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Stats { get; set; } = string.Empty;
        public uint Update { get; set; } = 0;
        public int History { get; set; } = 0;
        public int Offers { get; set; } = 0;
        public int Rental { get; set; } = 0;
        public int FbaFees { get; set; } = 0;
        public int Rating { get; set; } = 0;
    }
}