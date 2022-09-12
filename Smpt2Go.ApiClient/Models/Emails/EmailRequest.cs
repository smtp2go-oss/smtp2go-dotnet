using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// The base implementation for an email message to be sent via the <see cref="Smtp2GoApiService">Smtp2Go Email Service</see>.
    /// </summary>
    public abstract class EmailRequest : IApiRequest
    {
        private readonly List<string> _to;
        private readonly List<string> _cc = new List<string>();
        private readonly List<string> _bcc = new List<string>();
        private readonly List<EmailHeader> _customHeaders = new List<EmailHeader>();
        private readonly List<EmailBlob> _attachments = new List<EmailBlob>();
        private readonly List<EmailBlob> _inlines = new List<EmailBlob>();

        /// <summary>
        /// Creates an email request with minimum requirements.
        /// </summary>
        /// <param name="sender">The emails from email address.</param>
        /// <param name="to">One or more email addresses to send the email to.</param>
        public EmailRequest(string sender, params string[] to)
        {
            Sender = sender;
            _to = to.ToList();
        }

        /// <summary>
        /// A full API Key from the API Keys admin console.
        /// </summary>
        [JsonPropertyName("api_key")]
        public string? ApiKey { get; set; }

        /// <summary>
        /// An array of email addresses (up to 100) to send to, eg. ["john@example.com", "jane@example.com"].
        /// </summary>
        [JsonPropertyName("to")]
        public IEnumerable<string> To { get { return _to; } }

        /// <summary>
        /// An array of email addresses (up to 100) to cc to, eg. ["john@example.com", "jane@example.com"].
        /// </summary>
        [JsonPropertyName("cc")]
        public IEnumerable<string> Cc { get { return _cc; } }

        /// <summary>
        /// An array of email addresses (up to 100) to cc to, eg. ["john@example.com", "jane@example.com"].
        /// </summary>
        [JsonPropertyName("bcc")]
        public IEnumerable<string> Bcc { get { return _bcc; } }

        /// <summary>
        /// The email address to send from, eg. "john@example.com".
        /// </summary>
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// An optional set of custom headers to be applied to the email.
        /// </summary>
        [JsonPropertyName("custom_headers")]
        public IEnumerable<EmailHeader> CustomHeaders { get { return _customHeaders; } }

        /// <summary>
        /// An array of attachment objects to be attached to the email.
        /// </summary>
        [JsonPropertyName("attachments")]
        public IEnumerable<EmailBlob> Attachments { get { return _attachments; } }

        /// <summary>
        /// An array of images to be inlined into the email.
        /// </summary>
        [JsonPropertyName("inlines")]
        public IEnumerable<EmailBlob> InlineImages { get { return _inlines; } }

        /// <summary>
        /// Specify the version of the email structure, can be set as 1 or 2, default is 1.
        /// </summary>
        [JsonPropertyName("version")]
        public int EmailStructureVersion { get; set; } = 1;

        /// <summary>
        /// Add a correctly formatted to email address with optional display name.
        /// </summary>
        /// <param name="email">The email to send to.</param>
        /// <param name="displayName">The display name for the email address.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddToAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _to.Add($"{displayName} <{email}>");
            else
                _to.Add($"{email}");

            return this;
        }

        /// <summary>
        /// Add a correctly formatted cc email address with optional display name.
        /// </summary>
        /// <param name="email">The email to cc send to.</param>
        /// <param name="displayName">The display name for the email address.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddCcAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _cc.Add($"{displayName} <{email}>");
            else
                _cc.Add($"{email}");

            return this;
        }

        /// <summary>
        /// Add a correctly formatted bcc email address with optional display name.
        /// </summary>
        /// <param name="email">The email to bcc send to.</param>
        /// <param name="displayName">The display name for the email address.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddBccAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _bcc.Add($"{displayName} <{email}>");
            else
                _bcc.Add($"{email}");

            return this;
        }

        /// <summary>
        /// If not already present, adds a custom header and associated value to the custom headers collection.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddCustomHeader(string header, string value)
        {
            if (!string.IsNullOrWhiteSpace(header) && !string.IsNullOrWhiteSpace(value))
            {
                if (!_customHeaders.Exists(x => x.Header == header))
                {
                    _customHeaders.Add(new EmailHeader(header, value));
                }
            }

            return this;
        }

        private EmailRequest AddAttachment(string fileName, string fileBlob, string mimetype, List<EmailBlob> target)
        {
            if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(fileBlob) && !string.IsNullOrWhiteSpace(mimetype))
            {
                if (!target.Exists(x => x.FileName == fileName))
                {
                    target.Add(new EmailBlob(fileName, fileBlob, mimetype));
                }
            }

            return this;
        }

        /// <summary>
        /// Adds an inline image to the InlineImages collection.
        /// </summary>
        /// <param name="fileName">The file name for the inline image.</param>
        /// <param name="fileBlob">The base64 formatted blob string defining the inline image.</param>
        /// <param name="mimetype">The mime type definition for the inline image.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddInlineImage(string fileName, string fileBlob, string mimetype)
        {
            return AddAttachment(fileName, fileBlob, mimetype, _inlines);
        }



        /// <summary>
        /// Adds an email file attachment to the Attachments collection.
        /// </summary>
        /// <param name="fileName">The file name for the file attachment.</param>
        /// <param name="fileBlob">The base64 formatted blob string defining the file attachment.</param>
        /// <param name="mimetype">The mime type definition for the file attachment.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddAttachment(string fileName, string fileBlob, string mimetype)
        {
            return AddAttachment(fileName, fileBlob, mimetype, _attachments);
        }

        private EmailRequest AddFileAttachment(string filePath, string mimetype, List<EmailBlob> target)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(mimetype))
            {
                if (File.Exists(filePath))
                {
                    var fileBlob = Convert.ToBase64String(File.ReadAllBytes(filePath));

                    var fileName = Path.GetFileName(filePath);

                    AddAttachment(fileName, fileBlob, mimetype, target);
                }
                else throw new FileNotFoundException($"File not found at path {filePath}.", filePath);
            }

            return this;
        }

        /// <summary>
        /// Adds an inline image from a local system file path to the InlineImages collection.
        /// </summary>
        /// <param name="filePath">The local system file path the image is located.</param>
        /// <param name="mimetype">The mime type definition for the inline image.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddInlineImage(string filePath, string mimetype)
        {
            return AddFileAttachment(filePath, mimetype, _inlines);
        }

        /// <summary>
        /// Adds an email file attachment from a local system file path to the Attachments collection.
        /// </summary>
        /// <param name="filePath">The local system file path the image is located.</param>
        /// <param name="mimetype">The mime type definition for the inline image.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public EmailRequest AddAttachment(string filePath, string mimetype)
        {
            return AddFileAttachment(filePath, mimetype, _attachments);
        }
    }
}
