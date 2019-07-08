namespace Keepa.NET_Core.Requests
{
    public class SearchRequest
    {
        public string DomainId { get; set; }
        public string Type { get; set; }
        public string Term { get; set; }
    }
}