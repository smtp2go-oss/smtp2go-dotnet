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

        /// <summary>
        /// The subject of the email to be sent.
        /// </summary>
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        /// <summary>
        /// An HTML encoded email body.
        /// </summary>
        [JsonPropertyName("text_body")]
        public string? BodyText { get; set; }

        /// <summary>
        /// An HTML encoded email body.
        /// </summary>
        [JsonPropertyName("html_body")]
        public string? BodyHtml { get; set; }
    }
}
