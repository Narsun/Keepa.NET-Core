using Keepa.NET_Core.Entities;
using Keepa.NET_Core.Exceptions;
using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using LogService;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

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

        public Dictionary<string, Seller> FetchSellerInfo(SellerInfoRequest requestModel)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", requestModel.DomainId);
            request.AddQueryParameter("seller", requestModel.SellerId);
            request.AddQueryParameter("storefront", requestModel.Storefront.ToString());

            SellerInfoResponse response = GetResponse<SellerInfoResponse>(request);

            return response.Sellers;
        }

        public Product[] FetchProducts(ProductRequest requestModel)
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

            ProductResponse response = GetResponse<ProductResponse>(request);

            return response.Products;
        }

        public Deal[] FetchDeals(DealRequest requestModel)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(requestModel));

            DealResponse response = GetResponse<DealResponse>(request);

            Deal[] deals = null;

            try
            {
                if (response.Content != null)
                {
                    deals = response.Content.Deals;
                }
            }
            catch (NullReferenceException ex)
            {
                Logger.Fatal(ex.Message);
                Logger.Fatal($"Null reference response on DealRequest: page:{requestModel.Page}");
            }

            return deals;
        }

        public RetrieveTokenStatusResponse FetchTokenStatus()
        {
            RestRequest request = new RestRequest("token", Method.POST, DataFormat.Json);

            return GetResponse<RetrieveTokenStatusResponse>(request);
        }

        private T GetResponse<T>(RestRequest request) where T : ResponseBase
        {
            IRestResponse restResponse = _restClient.Execute(request);

            if (restResponse.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new KeepaException("Not enough tokens.");
            }

            T response = JsonConvert.DeserializeObject<T>(restResponse.Content);

            try
            {
                if (response.Error != null)
                {
                    Logger.Error($"RestResponseContent: {restResponse.Content}\nError: {response.Error.Message}");
                    throw new KeepaException(response.Error.Message);
                }

                Logger.Info($"Tokens left: {response.TokensLeft}");
            }
            catch (NullReferenceException ex)
            {
                Logger.Fatal(ex.Message);
                Logger.Fatal($"Null reference on response content: {restResponse.Content}");
            }
            return response;
        }
    }
}
