using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_Botinochki.ApiClient
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T> Get<T>(string endpoint)
        {
            var response = await _client.ExecuteAsync<T>(new RestRequest(endpoint, Method.Get));
            return response.Data;
        }

        public async Task<T> Post<T>(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);

            var response = await _client.ExecuteAsync<T>(request);
            return response.Data;
        }

    }
}
