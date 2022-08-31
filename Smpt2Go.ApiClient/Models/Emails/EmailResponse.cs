using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailResponse : IApiResponse
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = null!;

        [JsonPropertyName("data")]
        public EmailResponseData Data { get; set; } = null!;

        public string ResponseStatus { get; set; } = null!;
    }
}
