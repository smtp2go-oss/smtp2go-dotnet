using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// The email response object that is returned from the email services in the <see cref="Smtp2GoApiService">Smtp2Go Email Service</see>.
    /// </summary>
    public class EmailResponse : IApiResponse
    {
        /// <summary>
        /// A Unique ID for this request.
        /// </summary>
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = null;

        /// <summary>
        ///Email data returned by the Smtp2Go API endpoint.
        /// </summary>
        [JsonPropertyName("data")]
        public EmailResponseData Data { get; set; } = null;

        /// <summary>
        /// The HTTP status message returned by the API Client.
        /// </summary>
        public string ResponseStatus { get; set; } = null;
    }
}
