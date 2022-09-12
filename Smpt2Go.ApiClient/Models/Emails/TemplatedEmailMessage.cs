using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Smtp2Go.Api.Models.Emails
{
    /// <summary>
    /// A templated email message to be sent via the <see cref="Smtp2GoApiService">Smtp2Go Email Service</see>.
    /// </summary>
    public class TemplatedEmailMessage : EmailRequest
    {
        private readonly Dictionary<string, string> _templateVariables = new Dictionary<string, string>();

        /// <summary>
        /// Creates a templated email message with the minimal settings required to succesfully send via the Smtp2Go API Client.
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="sender"></param>
        /// <param name="to"></param>
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

        /// <summary>
        /// Adds a template variable and asssociated value to this templated email message.
        /// </summary>
        /// <param name="variableName">The variable name to match a value to in this templated email message.</param>
        /// <param name="variableValue">The value to use in this templated email message.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public TemplatedEmailMessage AddTemplateVariable(string variableName, string variableValue)
        {
            if (!string.IsNullOrWhiteSpace(variableName) && !_templateVariables.ContainsKey(variableName))
            {
                _templateVariables.Add(variableName, variableValue);
            }

            return this;
        }
    }
}
