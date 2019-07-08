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


        public MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest mostRatedSellersRequest)
        {
            RestRequest request = new RestRequest("topseller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", mostRatedSellersRequest.DomainId);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<MostRatedSellersResponse>(response.Content);
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

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<ProductResponse>(response.Content);
        }

        public ProductResponse ProductSearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<ProductResponse>(response.Content);
        }

        public CategoryResponse CategorySearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<CategoryResponse>(response.Content);
        }

        public CategoryResponse CategoryLookup(CategoryLookupRequest categoryLookup)
        {
            RestRequest request = new RestRequest("category", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", categoryLookup.DomainId);
            request.AddQueryParameter("category", categoryLookup.CategoryId);
            request.AddQueryParameter("parents", categoryLookup.IncludeParents);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<CategoryResponse>(response.Content);
        }

        public SellerInfoResponse FetchSellerInfo(SellerInfoRequest sellerInfo)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", sellerInfo.DomainId);
            request.AddQueryParameter("seller", sellerInfo.SellerId);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<SellerInfoResponse>(response.Content);
        }

        public DealResponse FetchDeals(DealRequest deal)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(deal));

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<DealResponse>(response.Content);
        }

        public RetrieveTokenStatusResponse FetchTokenStatus()
        {
            RestRequest request = new RestRequest("token", Method.POST, DataFormat.Json);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<RetrieveTokenStatusResponse>(response.Content);
        }

        private IRestResponse ExecuteRequest(RestRequest request)
        {
            return _restClient.Execute(request);
        }
    }
}
