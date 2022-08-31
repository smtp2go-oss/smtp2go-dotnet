using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailRequest : IApiRequest
    {
        private readonly List<string> _to;
        private readonly List<string> _cc = new List<string>();
        private readonly List<string> _bcc = new List<string>();
        private readonly List<EmailHeader> _customHeaders = new List<EmailHeader>();
        private readonly List<EmailBlob> _attachments = new List<EmailBlob>();
        private readonly List<EmailBlob> _inlines = new List<EmailBlob>();

        public EmailRequest(string sender, params string[] to)
        {
            Sender = sender;
            _to = to.ToList();
        }

        [JsonPropertyName("api_key")]
        public string? ApiKey { get; set; }

        [JsonPropertyName("to")]
        public IEnumerable<string> To { get { return _to; } }

        [JsonPropertyName("cc")]
        public IEnumerable<string> Cc { get { return _cc; } }

        [JsonPropertyName("bcc")]
        public IEnumerable<string> Bcc { get { return _bcc; } }

        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        [JsonPropertyName("custom_headers")]
        public IEnumerable<EmailHeader> CustomHeaders { get { return _customHeaders; } }

        [JsonPropertyName("attachments")]
        public IEnumerable<EmailBlob> Attachments { get { return _attachments; } }

        [JsonPropertyName("inlines")]
        public IEnumerable<EmailBlob> InlineImages { get { return _inlines; } }

        [JsonPropertyName("version")]
        public int EmailStructureVersion { get; set; } = 1;

        public void AddToAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _to.Add($"{displayName} <{email}>");
            else
                _to.Add($"{email}");
        }

        public void AddCcAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _cc.Add($"{displayName} <{email}>");
            else
                _cc.Add($"{email}");
        }

        public void AddBccAddress(string email, string? displayName = null)
        {
            if (!string.IsNullOrWhiteSpace(displayName))
                _bcc.Add($"{displayName} <{email}>");
            else
                _bcc.Add($"{email}");
        }

        public void AddCustomHeader(string header, string value)
        {
            if (!string.IsNullOrWhiteSpace(header) && !string.IsNullOrWhiteSpace(value))
            {
                if (!_customHeaders.Exists(x => x.Header == header))
                {
                    _customHeaders.Add(new EmailHeader(header, value));
                }
            }
        }

        public void AddInlineImage(string fileName, string fileBlob, string mimetype)
        {
            AddAttachment(fileName, fileBlob, mimetype, _inlines);
        }

        public void AddInlineImage(string filePath, string mimetype)
        {
            AddFileAttachment(filePath, mimetype, _inlines);
        }

        public void AddAttachment(string fileName, string fileBlob, string mimetype)
        {
            AddAttachment(fileName, fileBlob, mimetype, _attachments);
        }

        public void AddAttachment(string filePath, string mimetype)
        {
            AddFileAttachment(filePath, mimetype, _attachments);
        }

        private void AddFileAttachment(string filePath, string mimetype, List<EmailBlob> target)
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
        }

        private void AddAttachment(string fileName, string fileBlob, string mimetype, List<EmailBlob> target)
        {
            if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(fileBlob) && !string.IsNullOrWhiteSpace(mimetype))
            {
                if (!target.Exists(x => x.FileName == fileName))
                {
                    target.Add(new EmailBlob(fileName, fileBlob, mimetype));
                }
            }
        }
    }
}
