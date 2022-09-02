using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class EmailBlob
    {
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
        /// The mime type to use for the attachment
        /// </summary>
        [JsonPropertyName("mimetype")]
        public string MimeType { get; }
    }
}
