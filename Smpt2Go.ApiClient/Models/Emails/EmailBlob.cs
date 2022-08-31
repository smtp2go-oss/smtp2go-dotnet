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

        [JsonPropertyName("filename")]
        public string FileName { get; }

        [JsonPropertyName("fileblob")]
        public string FileBlob { get; }

        [JsonPropertyName("mimetype")]
        public string MimeType { get; }
    }
}
