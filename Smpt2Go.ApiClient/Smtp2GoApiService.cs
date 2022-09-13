using Smtp2Go.Api.Models.Emails;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    /// <summary>
    /// The API Service used to send Smtp2Go requests via an <see cref="IApiClient"/> implementation.
    /// </summary>
    public class Smtp2GoApiService : IApiService
    {
        /// <summary>
        /// Creates an <see cref="Smtp2GoApiService"/> that will use the provided <see cref="IApiClient"/> instance to interact with certain Smtp2Go API endpoints.
        /// </summary>
        /// <param name="apiClient">An API client instance to be used to interact with the Smtp2Go API.</param>
        public Smtp2GoApiService(IApiClient apiClient)
        {
            Client = apiClient;
        }

        /// <summary>
        /// An implementation of an <see cref="IApiClient"/> provided during instantiation.
        /// </summary>
        public IApiClient Client { get; }

        /// <inheritdoc/>
        public async Task<EmailResponse> SendEmail(EmailMessage request)
        {
            return await Client.SendReceive(request, new EmailResponse(), "email/send");
        }

        /// <inheritdoc/>
        public async Task<EmailResponse> SendEmail(string bodyHtml, string subject, string sender, params string[] toAddresses)
        {
            return await Client.SendReceive(new EmailMessage(bodyHtml, subject, sender, toAddresses), new EmailResponse(), "email/send");
        }

        /// <inheritdoc/>
        public async Task<EmailResponse> SendTemplatedEmail(TemplatedEmailMessage request)
        {
            return await Client.SendReceive(request, new EmailResponse(), "email/send");
        }
    }
}
