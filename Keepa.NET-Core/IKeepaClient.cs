using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;

namespace Keepa.NET_Core
{
    internal interface IKeepaClient
    {
        ProductFindResponse FindProduct(ProductFindRequest requestModel);

        BestSellersResponse FetchBestSellers(BestSellersRequest requestModel);

        MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest requestModel);

        ProductResponse FetchProduct(ProductRequest requestModel);

        ProductResponse ProductSearch(SearchRequest requestModel);

        CategoryResponse CategorySearch(SearchRequest requestModel);

        CategoryResponse CategoryLookup(CategoryLookupRequest requestModel);

        SellerInfoResponse FetchSellerInfo(SellerInfoRequest requestModel);

        DealResponse FetchDeals(DealRequest requestModel);

        RetrieveTokenStatusResponse FetchTokenStatus();
    }
}