using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// An email message to be sent via the <see cref="Smtp2GoApiService">Smtp2Go Email Service</see>.
    /// </summary>
    public class EmailMessage : EmailRequest
    {
        /// <summary>
        /// Creates an email message.
        /// </summary>
        /// <param name="sender">The emails from email address.</param>
        /// <param name="to">One or more email addresses to send the email to, formatted as 'display_name &lt;email_address&gt;'.</param>
        public EmailMessage(string sender = null!, params string[] to) : base(sender, to) { }

        /// <summary>
        /// Creates an email message.
        /// </summary>
        /// <param name="bodyHtml">The HTML formatted string that forms the body of the email.</param>
        /// <param name="subject">The subject of the email to be sent.</param>
        /// <param name="sender">The emails from email address.</param>
        /// <param name="to">One or more email addresses to send the email to, formatted as 'display_name &lt;email_address&gt;'.</param>
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
