using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailResponse : IApiResponse
    {
        /// <summary>
        /// A Unique ID for this request.
        /// </summary>
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = null!;

        //Email data returned by the smtp2go API endpoint.
        [JsonPropertyName("data")]
        public EmailResponseData Data { get; set; } = null!;

        /// <summary>
        /// The HTTP status message returned by the API Client.
        /// </summary>
        public string ResponseStatus { get; set; } = null!;
    }
}
