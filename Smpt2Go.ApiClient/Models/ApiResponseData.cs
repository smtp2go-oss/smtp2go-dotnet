using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models
{
    /// <summary>
    /// The base implementation for the email response data object that is returned from the email services in the <see cref="Smtp2GoApiService">Smtp2Go Email Service</see>.
    /// </summary>
    public abstract class ApiResponseData : IApiResponseData
    {
        /// <summary>
        /// An error string.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; } = null;

        /// <summary>
        /// An API Error Code string.
        /// </summary>
        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; } = null;
    }
}
