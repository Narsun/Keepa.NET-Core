namespace Keepa.NET_Core.Requests
{
    public class ProductRequest
    {
        public int DomainId { get; set; }
        public string Asin { get; set; }
        public string Code { get; set; }
        public string Stats { get; set; }
        public uint Update { get; set; }
        public int History { get; set; }
        public int Offers { get; set; }
        public int Rental { get; set; }
        public int FbaFees { get; set; }
        public int Rating { get; set; }
    }
}