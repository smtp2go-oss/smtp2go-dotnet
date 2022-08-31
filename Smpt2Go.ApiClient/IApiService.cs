using Smtp2Go.Api.Models.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    public interface IApiService
    {
        IApiClient Client { get; }

        Task<EmailResponse> SendEmail(EmailMessage request);

        Task<EmailResponse> SendEmail(string bodyHtml, string subject, string sender, params string[] toAddresses);

        Task<EmailResponse> SendTemplatedEmail(TemplatedEmailMessage request);
    }
}
