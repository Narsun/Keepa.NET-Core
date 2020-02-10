using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using System.Threading.Tasks;

namespace Keepa.NET_Core
{
    public interface IKeepaClient
    {
        public Task<ProductFindResponse> FindProductAsync(ProductFindRequest requestModel);
        public Task<BestSellersResponse> FetchBestSellersAsync(BestSellersRequest requestModel);
        public Task<MostRatedSellersResponse> FetchMostRatedSellersAsync(MostRatedSellersRequest requestModel);
        public Task<ProductResponse> FetchProductsAsync(ProductRequest requestModel);
        public Task<ProductResponse> ProductSearchAsync(SearchRequest requestModel);
        public Task<CategoryResponse> CategorySearchAsync(SearchRequest requestModel);
        public Task<CategoryResponse> CategoryLookupAsync(CategoryLookupRequest requestModel);
        public Task<SellerInfoResponse> FetchSellersInfoAsync(SellerInfoRequest requestModel);
        public Task<DealResponse> FetchDealsAsync(DealRequest requestModel);
        public Task<RetrieveTokenStatusResponse> FetchTokenStatusAsync();
    }
}