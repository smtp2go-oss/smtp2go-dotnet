using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    public class TemplatedEmailMessage : EmailRequest
    {
        private readonly Dictionary<string, string> _templateVariables = new Dictionary<string, string>();

        public TemplatedEmailMessage(string templateId, string sender, params string[] to) : base(sender, to)
        {
            TemplateId = templateId;
        }

        /// <summary>
        /// A template id to generate the email.
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; }

        /// <summary>
        /// The JSON data to be used to populate the email template.
        /// </summary>
        [JsonPropertyName("template_data")]
        public IDictionary<string, string> TemplateVariables { get { return _templateVariables; } }

        public void AddTemplateVariable(string variableName, string variableValue)
        {
            if (!string.IsNullOrWhiteSpace(variableName) && !_templateVariables.ContainsKey(variableName))
            {
                _templateVariables.Add(variableName, variableValue);
            }
        }
    }
}
