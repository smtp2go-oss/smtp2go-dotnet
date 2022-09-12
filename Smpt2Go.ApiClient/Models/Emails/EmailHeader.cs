using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// A custom email header for an email message.
    /// </summary>
    public class EmailHeader
    {
        /// <summary>
        /// Creates a custom email header.
        /// </summary>
        /// <param name="header">The custom header name.</param>
        /// <param name="value">The custom header value.</param>
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
