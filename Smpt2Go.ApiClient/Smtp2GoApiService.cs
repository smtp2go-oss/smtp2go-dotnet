using Smtp2Go.Api.Models.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    public class Smtp2GoApiService : IApiService
    {
        public Smtp2GoApiService(IApiClient apiClient)
        {
            Client = apiClient;
        }

        public IApiClient Client { get; }

        public async Task<EmailResponse> SendEmail(EmailMessage request)
        {
            return await Client.SendReceive(request, new EmailResponse(), "email/send");
        }

        public async Task<EmailResponse> SendEmail(string bodyHtml, string subject, string sender, params string[] toAddresses)
        {
            return await Client.SendReceive(new EmailMessage(bodyHtml, subject, sender, toAddresses), new EmailResponse(), "email/send");
        }

        public async Task<EmailResponse> SendTemplatedEmail(TemplatedEmailMessage request)
        {
            return await Client.SendReceive(request, new EmailResponse(), "email/send");
        }
    }
}
