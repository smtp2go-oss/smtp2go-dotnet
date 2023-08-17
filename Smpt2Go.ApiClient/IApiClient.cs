using Smtp2Go.Api.Models;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    /// <summary>
    /// Provides the base API Client interface for API interactions.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// An interface for a generic send and receive API function for Smtp2Go API interactions, ensuring all generated API requests contain an API key and have capacity to receive response information from any request made.
        /// </summary>
        /// <typeparam name="X">An implementation of an <see cref="IApiRequest">IApiRequest</see> object</typeparam>
        /// <typeparam name="T">An implementation of an <see cref="IApiResponse">IApiResponse</see> object</typeparam>
        /// <param name="request">An instance of an <see cref="IApiRequest">IApiRequest</see> implementation.</param>
        /// <param name="response">An instance of an <see cref="IApiResponse">IApiResponse</see> implementation.</param>
        /// <param name="endpoint"></param>
        /// <returns>The supplied <see cref="IApiResponse">IApiResponse</see> instance containing API response data.</returns>
        Task<T> SendReceive<X, T>(X request, T response, string endpoint) where T : IApiResponse where X : IApiRequest;
    }
}
