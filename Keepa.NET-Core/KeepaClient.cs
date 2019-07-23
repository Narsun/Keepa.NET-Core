using Keepa.NET_Core.Exceptions;
using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Keepa.NET_Core
{
    public class KeepaClient : IKeepaClient
    {
        private readonly RestClient _restClient;

        private readonly string _apiUrl = "https://api.keepa.com/";

        public KeepaClient(string privateKey)
        {
            _restClient = new RestClient(_apiUrl);
            _restClient.AddDefaultQueryParameter("key", privateKey);
        }

        public ProductFindResponse FindProduct(ProductFindRequest requestModel)
        {
            RestRequest request = new RestRequest("query", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(requestModel));

            var response = GetResponse<ProductFindResponse>(request);

            return response;
        }

        public BestSellersResponse FetchBestSellers(BestSellersRequest requestModel)
        {
            RestRequest request = new RestRequest("bestsellers", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("category", requestModel.CategoryId);
            request.AddQueryParameter("range", requestModel.Range);

            return GetResponse<BestSellersResponse>(request);
        }

        public MostRatedSellersResponse FetchMostRatedSellers(MostRatedSellersRequest requestModel)
        {
            RestRequest request = new RestRequest("topseller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);

            return GetResponse<MostRatedSellersResponse>(request);
        }

        public ProductResponse FetchProduct(ProductRequest requestModel)
        {
            RestRequest request = new RestRequest("product", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId.ToString());

            if (requestModel.Asin != null)
            {
                request.AddQueryParameter("asin", requestModel.Asin);
            }
            if (requestModel.Code != null)
            {
                request.AddQueryParameter("code", requestModel.Code);
            }
            /*
            if (!string.IsNullOrEmpty(requestModel.Stats))
            {
                request.AddQueryParameter("stats", requestModel.Stats);
            }
            */
            if (requestModel.Update > 0)
            {
                request.AddQueryParameter("update", requestModel.Update.ToString());
            }
            
            if (requestModel.History > 0)
            {
                request.AddQueryParameter("history", requestModel.History.ToString());
            }
            if (requestModel.Offers > 0)
            {
                request.AddQueryParameter("offers", requestModel.Offers.ToString());
            }
            if (requestModel.Rental > 0)
            {
                request.AddQueryParameter("rental", requestModel.Rental.ToString());
            }
            if (requestModel.FbaFees > 0)
            {
                request.AddQueryParameter("fbafees", requestModel.FbaFees.ToString());
            }
            if (requestModel.Rating > 0)
            {
                request.AddQueryParameter("rating", requestModel.Rating.ToString());
            }

            return GetResponse<ProductResponse>(request);
        }

        public ProductResponse ProductSearch(SearchRequest requestModel)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("type", requestModel.Type);
            request.AddQueryParameter("term", requestModel.Term);

            return GetResponse<ProductResponse>(request);
        }

        public CategoryResponse CategorySearch(SearchRequest requestModel)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("type", requestModel.Type);
            request.AddQueryParameter("term", requestModel.Term);

            return GetResponse<CategoryResponse>(request);
        }

        public CategoryResponse CategoryLookup(CategoryLookupRequest requestModel)
        {
            RestRequest request = new RestRequest("category", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("category", requestModel.CategoryId);
            request.AddQueryParameter("parents", requestModel.IncludeParents);

            return GetResponse<CategoryResponse>(request);
        }

        public SellerInfoResponse FetchSellerInfo(SellerInfoRequest requestModel)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("seller", requestModel.SellerId);

            return GetResponse<SellerInfoResponse>(request);
        }

        public DealResponse FetchDeals(DealRequest requestModel)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(requestModel));

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
