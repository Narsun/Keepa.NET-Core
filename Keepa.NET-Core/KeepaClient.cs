using Keepa.NET_Core.Exceptions;
using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Keepa.NET_Core
{
    public class KeepaClient : IKeepaClient
    {
        private readonly RestClient _restClient;
        private const string _apiEndpoint = "https://api.keepa.com/";

        public KeepaClient(string apiKey)
        {
            _restClient = new RestClient(_apiEndpoint);
            _restClient.AddDefaultQueryParameter("key", apiKey);
        }
        public async Task<ProductFindResponse> FindProductAsync(ProductFindRequest requestModel)
        {
            RestRequest request = new RestRequest("query", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(requestModel));

            return await GetResponseAsync<ProductFindResponse>(request);
        }
        public async Task<BestSellersResponse> FetchBestSellersAsync(BestSellersRequest requestModel)
        {
            RestRequest request = new RestRequest("bestsellers", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("category", requestModel.CategoryId);
            request.AddQueryParameter("range", requestModel.Range);

            return await GetResponseAsync<BestSellersResponse>(request);
        }
        public async Task<MostRatedSellersResponse> FetchMostRatedSellersAsync(MostRatedSellersRequest requestModel)
        {
            RestRequest request = new RestRequest("topseller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);

            return await GetResponseAsync<MostRatedSellersResponse>(request);
        }
        public async Task<ProductResponse> ProductSearchAsync(SearchRequest requestModel)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("type", requestModel.Type);
            request.AddQueryParameter("term", requestModel.Term);

            return await GetResponseAsync<ProductResponse>(request);
        }
        public async Task<CategoryResponse> CategorySearchAsync(SearchRequest requestModel)
        {
            RestRequest request = new RestRequest("search", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("type", requestModel.Type);
            request.AddQueryParameter("term", requestModel.Term);

            return await GetResponseAsync<CategoryResponse>(request);
        }
        public async Task<CategoryResponse> CategoryLookupAsync(CategoryLookupRequest requestModel)
        {
            RestRequest request = new RestRequest("category", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("category", requestModel.CategoryId);
            request.AddQueryParameter("parents", requestModel.IncludeParents);

            return await GetResponseAsync<CategoryResponse>(request);
        }
        public async Task<SellerInfoResponse> FetchSellersInfoAsync(SellerInfoRequest requestModel)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId.ToString());
            request.AddQueryParameter("seller", requestModel.SellerId);
            request.AddQueryParameter("storefront", requestModel.Storefront.ToString());

            return await GetResponseAsync<SellerInfoResponse>(request);
        }
        public async Task<ProductResponse> FetchProductsAsync(ProductRequest requestModel)
        {
            RestRequest request = new RestRequest("product", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId.ToString());

            if (!string.IsNullOrEmpty(requestModel.Asin))
            {
                request.AddQueryParameter("asin", requestModel.Asin);
            }
            if (!string.IsNullOrEmpty(requestModel.Code))
            {
                request.AddQueryParameter("code", requestModel.Code);
            }

            if (!string.IsNullOrEmpty(requestModel.Stats))
            {
                request.AddQueryParameter("stats", requestModel.Stats);
            }

            request.AddQueryParameter("update", requestModel.Update.ToString());

            request.AddQueryParameter("history", requestModel.History.ToString());

            request.AddQueryParameter("offers", requestModel.Offers.ToString());

            request.AddQueryParameter("rental", requestModel.Rental.ToString());

            request.AddQueryParameter("fbafees", requestModel.FbaFees.ToString());

            request.AddQueryParameter("rating", requestModel.Rating.ToString());

            return await GetResponseAsync<ProductResponse>(request);
        }
        public async Task<DealResponse> FetchDealsAsync(DealRequest requestModel)
        {
            var request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(requestModel));

            return  await GetResponseAsync<DealResponse>(request);
        }
        public async Task<RetrieveTokenStatusResponse> FetchTokenStatusAsync()
        {
            var request = new RestRequest("token", Method.POST, DataFormat.Json);

            return await GetResponseAsync<RetrieveTokenStatusResponse>(request);  
        }
        private async Task<IKeepaResponse> GetResponseAsync<IKeepaResponse>(RestRequest request)
        {
            var response = await _restClient.ExecuteAsync(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var keepaResponse = JsonConvert.DeserializeObject<IKeepaResponse>(response.Content);

                    return keepaResponse;
                }
                else if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 400)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ResponseBase>(response.Content);

                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                        throw new NotEnoughTokensException(errorResponse.Errors);
                    else
                        throw new KeepaException(errorResponse.Errors);
                }
            }
            throw new KeepaException("No content in response");
        }
    }
}