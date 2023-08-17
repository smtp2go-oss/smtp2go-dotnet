using Smtp2Go.Api.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    /// <summary>
    /// The Smtp2Go API Client for Smtp2Go API interactions.
    /// </summary>
    public class Smtp2GoApiClient : IApiClient
    {
        private readonly string _apiKey;
        private readonly string _apiBaseUrl;

        /// <summary>
        /// Creates an <see cref="IApiClient"/> implementation for Smtp2Go API Client interactions.
        /// </summary>
        /// <param name="apiKey">The API key to be used in all API client requests.</param>
        /// <param name="apiBaseUrl">The base URL, current default is '<see href="https://api.smtp2go.com/v3/"/>'.</param>
        public Smtp2GoApiClient(string apiKey, string apiBaseUrl = "https://api.smtp2go.com/v3/")
        {
            _apiKey = apiKey;
            _apiBaseUrl = apiBaseUrl;
        }

        /// <summary>
        /// A generic send and receive API function for Smtp2Go API interactions, ensuring all generated API requests contain an API key and have capacity to receive response information from any request made.
        /// </summary>
        /// <typeparam name="X">An implementation of an <see cref="IApiRequest">IApiRequest</see> object</typeparam>
        /// <typeparam name="T">An implementation of an <see cref="IApiResponse">IApiResponse</see> object</typeparam>
        /// <param name="request">An instance of an <see cref="IApiRequest">IApiRequest</see> implementation.</param>
        /// <param name="response">An instance of an <see cref="IApiResponse">IApiResponse</see> implementation.</param>
        /// <param name="endpoint"></param>
        /// <returns>The supplied <see cref="IApiResponse">IApiResponse</see> instance containing API response data.</returns>
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

            return response;
        }

    }
}
