using Smtp2Go.Api.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    public class Smtp2GoApiClient : IApiClient
    {
        private readonly string _apiKey;
        private readonly string _apiBaseUrl;

        public Smtp2GoApiClient(string apiKey, string apiBaseUrl = "https://api.smtp2go.com/v3/")
        {
            _apiKey = apiKey;
            _apiBaseUrl = apiBaseUrl;
        }

        public async Task<T> SendReceive<X, T>(X request, T response, string endpoint)
            where T : IApiResponse
            where X : IApiRequest
        {
            request.ApiKey = _apiKey;

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_apiBaseUrl);

            var json = JsonSerializer.Serialize(request);

            var apiResponse = await httpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));

            if (apiResponse.IsSuccessStatusCode)
            {
                response = await apiResponse.Content.ReadFromJsonAsync<T>();
            }

            if (response != null)
            {
                response.ResponseStatus = apiResponse.ReasonPhrase;
            }

            return response!;
        }

    }
}
