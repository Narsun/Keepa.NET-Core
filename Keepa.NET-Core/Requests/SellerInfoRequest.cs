namespace Keepa.NET_Core.Requests
{
    public class SellerInfoRequest
    {
        public int DomainId { get; set; }
        public string SellerId { get; set; }
        public int Storefront { get; set; }
        public int Update { get; set; }
    }
}