using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailMessage : EmailRequest
    {
        public EmailMessage(string sender, params string[] to) : base(sender, to) { }

        public EmailMessage(string? bodyHtml, string? subject, string sender, params string[] to) : base(sender, to)
        {
            Subject = subject;
            BodyHtml = bodyHtml;
        }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("text_body")]
        public string? BodyText { get; set; }

        [JsonPropertyName("html_body")]
        public string? BodyHtml { get; set; }
    }
}
