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

        [JsonPropertyName("header")]
        public string Header { get; }

        [JsonPropertyName("value")]
        public string Value { get; }
    }
}
