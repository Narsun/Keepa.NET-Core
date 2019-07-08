namespace Keepa.NET_Core.Requests
{
    public class CategoryLookupRequest
    {
        public string DomainId { get; set; }
        public string CategoryId { get; set; }
        public string IncludeParents { get; set; }
    }
}