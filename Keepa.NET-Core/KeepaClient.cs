using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

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


        public SellerInfoResponse GetSellerInfo(SellerInfoRequest sellerInfo)
        {
            RestRequest request = new RestRequest("seller", Method.POST, DataFormat.Json);

            request.AddQueryParameter("domain", sellerInfo.DomainId);
            request.AddQueryParameter("seller", sellerInfo.SellerId);

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<SellerInfoResponse>(response.Content);
        }


        public DealResponse GetDeals(DealRequest deal)
        {
            RestRequest request = new RestRequest("deal", Method.POST, DataFormat.Json);

            request.AddJsonBody(JsonConvert.SerializeObject(deal));

            var response = ExecuteRequest(request);

            return JsonConvert.DeserializeObject<DealResponse>(response.Content);
        }


        public RetrieveTokenStatusResponse GetTokenStatus()
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
