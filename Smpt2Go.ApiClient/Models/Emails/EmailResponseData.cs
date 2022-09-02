using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailResponseData : ApiResponseData
    {
        /// <summary>
        /// The number of emails that were successfully sent.
        /// </summary>
        [JsonPropertyName("succeeded")]
        public int Succeeded { get; set; }

        /// <summary>
        /// The number of emails that failed to be sent.
        /// </summary>
        [JsonPropertyName("failed")]
        public int Failed { get; set; }

        /// <summary>
        /// Any failures will be listed here.
        /// </summary>
        [JsonPropertyName("failures")]
        public IEnumerable<string> Failures { get; set; } = null!;

        /// <summary>
        /// The email ID generated if successfully sent.
        /// </summary>
        [JsonPropertyName("email_id")]
        public string EmailId { get; set; } = null!;
    }
}
