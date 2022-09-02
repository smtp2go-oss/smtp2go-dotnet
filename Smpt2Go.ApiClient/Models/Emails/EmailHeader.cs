using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailHeader
    {
        public EmailHeader(string header, string value)
        {
            Header = header;
            Value = value;
        }

        /// <summary>
        /// The email header name.
        /// </summary>
        [JsonPropertyName("header")]
        public string Header { get; }

        /// <summary>
        /// The email header value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; }
    }
}
