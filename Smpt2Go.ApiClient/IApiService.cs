using Smtp2Go.Api.Models.Emails;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    /// <summary>
    /// Provides the base API Service interface for Smtp2Go API Client interactions.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// An implementation of an <see cref="IApiClient"/> to be provided during instantiation.
        /// </summary>
        IApiClient Client { get; }

        /// <summary>
        /// Send an <see cref="EmailMessage"/> via the configured Smtp2Go Api Client to the "email/send" end point.
        /// </summary>
        /// <param name="request">A configured <see cref="EmailMessage"/>.</param>
        /// <returns>An <see cref="EmailResponse"/> containing response information from the Smtp2Go API.</returns>
        Task<EmailResponse> SendEmail(EmailMessage request);

        /// <summary>
        /// Send an email message via the configured Smtp2Go Api Client to the "email/send" end point.
        /// </summary>
        /// <param name="bodyHtml">The HTML formatted string that forms the body of the email.</param>
        /// <param name="subject">The subject of the email to be sent.</param>
        /// <param name="sender">The emails from email address.</param>
        /// <param name="toAddresses">One or more email addresses to send the email to, formatted as 'display_name &lt;email_address&gt;'.</param>
        /// <returns></returns>
        Task<EmailResponse> SendEmail(string bodyHtml, string subject, string sender, params string[] toAddresses);

        /// <summary>
        /// Send a <see cref="TemplatedEmailMessage"/> via the configured Smtp2Go Api Client to the "email/send" end point.
        /// </summary>
        /// <param name="request">A configured <see cref="TemplatedEmailMessage"/>.</param>
        /// <returns>An <see cref="EmailResponse"/> containing response information from the Smtp2Go API.</returns>
        Task<EmailResponse> SendTemplatedEmail(TemplatedEmailMessage request);
    }
}
