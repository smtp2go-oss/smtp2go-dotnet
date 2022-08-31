using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailResponseData : ApiResponseData
    {
        [JsonPropertyName("succeeded")]
        public int Succeeded { get; set; }

        [JsonPropertyName("failed")]
        public int Failed { get; set; }

        [JsonPropertyName("failures")]
        public IEnumerable<string> Failures { get; set; } = null!;

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; } = null!;
    }
}
