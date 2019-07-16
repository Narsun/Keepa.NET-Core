using Keepa.NET_Core.Exceptions;
using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Keepa.NET_Core
{
    public class KeepaClient
    {
        private readonly RestClient _restClient;

        private readonly string _apiUrl = "https://api.keepa.com/";

        public KeepaClient(string privateKey)
        {
            _restClient = new RestClient(_apiUrl);
            _restClient.AddDefaultQueryParameter("key", privateKey);
        }

        public ProductFindResponse FindProduct(ProductFindRequest findProduct)
        {
            RestRequest request = new RestRequest("query", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(findProduct));

            var response = GetResponse<ProductFindResponse>(request);

            return response;
        }

        public BestSellersResponse FetchBestSellers(BestSellersRequest bestSellers)
        {
            RestRequest request = new RestRequest("bestsellers", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", bestSellers.DomainId);
            request.AddQueryParameter("category", bestSellers.CategoryId);
            request.AddQueryParameter("range", bestSellers.Range);

            return GetResponse<BestSellersResponse>(request);
        }

        public MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest mostRatedSellersRequest)
        {
            RestRequest request = new RestRequest("topseller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", mostRatedSellersRequest.DomainId);

            return GetResponse<MostRatedSellersResponse>(request);
        }

        public ProductResponse FetchProduct(ProductRequest productRequest)
        {
            RestRequest request = new RestRequest("product", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", productRequest.DomainId);

            if (productRequest.Asin != null)
            {
                request.AddQueryParameter("asin", productRequest.Asin);
            }
            if (productRequest.Code != null)
            {
                request.AddQueryParameter("code", productRequest.Code);
            }

            return GetResponse<ProductResponse>(request);
        }

        public ProductResponse ProductSearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            return GetResponse<ProductResponse>(request);
        }

        public CategoryResponse CategorySearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            return GetResponse<CategoryResponse>(request);
        }

        public CategoryResponse CategoryLookup(CategoryLookupRequest categoryLookup)
        {
            RestRequest request = new RestRequest("category", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", categoryLookup.DomainId);
            request.AddQueryParameter("category", categoryLookup.CategoryId);
            request.AddQueryParameter("parents", categoryLookup.IncludeParents);

            return GetResponse<CategoryResponse>(request);
        }

        public SellerInfoResponse FetchSellerInfo(SellerInfoRequest sellerInfo)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", sellerInfo.DomainId);
            request.AddQueryParameter("seller", sellerInfo.SellerId);

            return GetResponse<SellerInfoResponse>(request);
        }

        public DealResponse FetchDeals(DealRequest deal)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(deal));

            return GetResponse<DealResponse>(request);
        }

        public RetrieveTokenStatusResponse FetchTokenStatus()
        {
            RestRequest request = new RestRequest("token", Method.POST, DataFormat.Json);

            return GetResponse<RetrieveTokenStatusResponse>(request);
        }

        private T GetResponse<T>(RestRequest request) where T : ResponseBase
        {
            IRestResponse restResponse = _restClient.Execute(request);

            T response;

            if (restResponse.IsSuccessful)
            {
                response = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ResponseBase>(restResponse.Content).Error;
                throw new KeepaException(error);
            }
            return response;
        }
    }
}
