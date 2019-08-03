using Keepa.NET_Core.Entities;
using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using System.Collections.Generic;

namespace Keepa.NET_Core
{
    internal interface IKeepaClient
    {
        ProductFindResponse FindProduct(ProductFindRequest requestModel);

        BestSellersResponse FetchBestSellers(BestSellersRequest requestModel);

        MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest requestModel);

        Product[] FetchProducts(ProductRequest requestModel);

        ProductResponse ProductSearch(SearchRequest requestModel);

        CategoryResponse CategorySearch(SearchRequest requestModel);

        CategoryResponse CategoryLookup(CategoryLookupRequest requestModel);

        Dictionary<string, Seller> FetchSellerInfo(SellerInfoRequest requestModel);

        Deal[] FetchDeals(DealRequest requestModel);

        RetrieveTokenStatusResponse FetchTokenStatus();
    }
}