using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models
{
    public abstract class ApiResponseData : IApiResponseData
    {
        [JsonPropertyName("error")]
        public string Error { get; set; } = null!;

        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; } = null!;
    }
}
