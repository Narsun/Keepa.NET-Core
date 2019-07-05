using Keepa.NET_Core.Requests;
using Keepa.NET_Core.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Keepa.NET_Core
{
    public class KeepaClient
    {
        private readonly RestClient _restClient;

        private readonly string _apiEndpoint = "https://api.keepa.com/";

        private readonly string _privateKey;

        public KeepaClient(string privateKey)
        {
            _privateKey = privateKey;

            _restClient = new RestClient();
        }

        public DealResponse GetDeals(DealRequest deal)
        {
            IRestResponse response = ExecuteRequest("deal", deal);

            return DeserializeResponseContent<DealResponse>(response.Content);
        }

        public T DeserializeResponseContent<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public IRestResponse ExecuteRequest<T>(string resource, T obj)
        {
            RestRequest restRequest = new RestRequest(resource)
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };
            restRequest.AddQueryParameter("key", _privateKey);

            restRequest.AddJsonBody(JsonConvert.SerializeObject(obj));
            return _restClient.Execute(restRequest);
        }
    }
}
