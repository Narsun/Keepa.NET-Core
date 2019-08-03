namespace Keepa.NET_Core.Requests
{
    public class SellerInfoRequest
    {
        public string DomainId { get; set; }
        public string SellerId { get; set; }
        public int Storefront { get; set; }
    }
}