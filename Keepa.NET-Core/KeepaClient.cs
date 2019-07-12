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

            var response = Execute(request);

            return JsonConvert.DeserializeObject<ProductFindResponse>(response.Content);
        }

        public BestSellersResponse FetchBestSellers(BestSellersRequest bestSellers)
        {
            RestRequest request = new RestRequest("bestsellers", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", bestSellers.DomainId);
            request.AddQueryParameter("category", bestSellers.CategoryId);
            request.AddQueryParameter("range", bestSellers.Range);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<BestSellersResponse>(response.Content);
        }

        public MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest mostRatedSellersRequest)
        {
            RestRequest request = new RestRequest("topseller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", mostRatedSellersRequest.DomainId);

            var response = Execute(request);

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

            var response = Execute(request);

            return JsonConvert.DeserializeObject<ProductResponse>(response.Content);
        }

        public ProductResponse ProductSearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<ProductResponse>(response.Content);
        }

        public CategoryResponse CategorySearch(SearchRequest searchRequest)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", searchRequest.DomainId);
            request.AddQueryParameter("type", searchRequest.Type);
            request.AddQueryParameter("term", searchRequest.Term);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<CategoryResponse>(response.Content);
        }

        public CategoryResponse CategoryLookup(CategoryLookupRequest categoryLookup)
        {
            RestRequest request = new RestRequest("category", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", categoryLookup.DomainId);
            request.AddQueryParameter("category", categoryLookup.CategoryId);
            request.AddQueryParameter("parents", categoryLookup.IncludeParents);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<CategoryResponse>(response.Content);
        }

        public SellerInfoResponse FetchSellerInfo(SellerInfoRequest sellerInfo)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", sellerInfo.DomainId);
            request.AddQueryParameter("seller", sellerInfo.SellerId);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<SellerInfoResponse>(response.Content);
        }

        public DealResponse FetchDeals(DealRequest deal)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(deal));

            var response = Execute(request);

            var dealsResponse = JsonConvert.DeserializeObject<DealResponse>(response.Content);

            return dealsResponse;
        }

        public RetrieveTokenStatusResponse FetchTokenStatus()
        {
            RestRequest request = new RestRequest("token", Method.POST, DataFormat.Json);

            var response = Execute(request);

            return JsonConvert.DeserializeObject<RetrieveTokenStatusResponse>(response.Content);
        }

        private IRestResponse Execute(RestRequest request)
        {
            IRestResponse response = _restClient.Execute(request);

            if (response.IsSuccessful == false)
            {
                var error = JsonConvert.DeserializeObject<ResponseBase>(response.Content).Error;
                throw new KeepaException(error);
            }
            return response;
        }
    }
}
