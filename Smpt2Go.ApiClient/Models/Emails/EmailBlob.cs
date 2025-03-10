﻿using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// A email attachment blob for an email message.
    /// </summary>
    public class EmailBlob
    {
        /// <summary>
        /// Creates a email attachment blob.
        /// </summary>
        /// <param name="fileName">The file name used for the attachment.</param>
        /// <param name="fileBlob">The base64 encoded file contents.</param>
        /// <param name="mimeType">The mime type to use for the attachment.</param>
        public EmailBlob(string fileName, string fileBlob, string mimeType)
        {
            FileName = fileName;
            FileBlob = fileBlob;
            MimeType = mimeType;
        }

        /// <summary>
        /// The file name used for the attachment.
        /// </summary>
        [JsonPropertyName("filename")]
        public string FileName { get; }

        /// <summary>
        /// The base64 encoded file contents.
        /// </summary>
        [JsonPropertyName("fileblob")]
        public string FileBlob { get; }

        /// <summary>
        /// The mime type to use for the attachment.
        /// </summary>
        [JsonPropertyName("mimetype")]
        public string MimeType { get; }
    }
}
