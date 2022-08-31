using Microsoft.Extensions.DependencyInjection;
using Smtp2Go.Api;
using Smtp2Go.Api.Models;
using Smtp2Go.Api.Models.Emails;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Smtp2GoTests
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ConfigureServices()
                .AddSingleton<TestApp>()
                .BuildServiceProvider()
                .GetService<TestApp>()
                .Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<IApiClient, Smtp2GoApiClient>(x => new Smtp2GoApiClient("api-08240B6EC06011EC9A03F23C91C88F4E"))
                .AddSingleton<IApiService, Smtp2GoApiService>();
        }
    }

    public class TestApp
    {
        private readonly IApiService _apiService;

        public TestApp(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task Run()
        {
            //var apiClientResponse = await _apiService.Client.SendReceive(sendEmailRequest, new SendEmailResponse(), "email/send");

            //Console.WriteLine($"API Client Request {apiClientResponse.RequestId} returned status {apiClientResponse.ResponseStatus}");

            //await SendEmailTest();

            await SendTemplatedEmailTest();
        }

        private async Task SendEmailTest()
        {
            var sendEmailRequest = new EmailMessage("<html><head></head><body><h1>.NET API Client Test HTML Body no TEXT body</h1></body></html>"
                , ".NET API Client Test (No Attachments)"
                , "Himself <him@keith.flowers>"
                , "That guy <keifjd@gmail.com>")
            {
                BodyText = ".NET API Client Test HTML as TEXT Body Ooops"
            };

            BindEmail(sendEmailRequest);

            var emailResponse = await _apiService.SendEmail(sendEmailRequest);

            DisplayResponse(emailResponse);
        }

        private async Task SendTemplatedEmailTest()
        {
            var sendTemplatedEmailRequest = new TemplatedEmailMessage("1375226"
                , "Himself <him@keith.flowers>"
                , "That guy <keifjd@gmail.com>");

            sendTemplatedEmailRequest.AddTemplateVariable("username", "Terrance");
            sendTemplatedEmailRequest.AddTemplateVariable("product_name", "The BEST EMAIL EVER");
            sendTemplatedEmailRequest.AddTemplateVariable("action_url", "https://www.smtp2go.com/");
            sendTemplatedEmailRequest.AddTemplateVariable("login_url", "https://app.smtp2go.com/login/");
            sendTemplatedEmailRequest.AddTemplateVariable("guide_url", "https://www.smtp2go.com/setup/");
            sendTemplatedEmailRequest.AddTemplateVariable("sender_name", "Pedro");

            BindEmail(sendTemplatedEmailRequest);

            var emailResponse = await _apiService.SendTemplatedEmail(sendTemplatedEmailRequest);

            DisplayResponse(emailResponse);
        }

        private void BindEmail(EmailRequest emailRequest)
        {
            emailRequest.AddToAddress("keifjd+1@gmail.com");
            emailRequest.AddToAddress("keifjd+2@gmail.com", "JimmyToo");

            emailRequest.AddCcAddress("him@keith.flowers", "CcHimself");

            emailRequest.AddBccAddress("keith@phosphor.co.nz");

            emailRequest.AddCustomHeader("Reply-To", "Someone Else <him+1@keith.flowers>");

            emailRequest.AddAttachment("Attachment.txt", "LS0tIENvbnRlbnRzIC0tLQ==", "text/plain");
            emailRequest.AddAttachment("C:\\Temp\\Attachment.docx", "application/msword");

            emailRequest.AddInlineImage("smtp2go_base64.png",
                "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"
                , "image/png");
            emailRequest.AddInlineImage("C:\\Temp\\smtp2go.png", "image/png");

            emailRequest.EmailStructureVersion = 2;
        }

        private void DisplayResponse(EmailResponse response)
        {
            Console.WriteLine($"API Service Request {response.RequestId} returned status {response.ResponseStatus}\n");

            if (response.Data != null)
            {
                if (!string.IsNullOrWhiteSpace(response.Data.ErrorCode))
                {
                    Console.WriteLine($"\tError Code: {response.Data.ErrorCode}");
                    Console.WriteLine($"\tError: {response.Data.Error}");
                }
                else
                {
                    Console.WriteLine($"\tEmailId: {response.Data.EmailId}");
                    Console.WriteLine($"\tSucceeded: {response.Data.Succeeded}");
                    Console.WriteLine($"\tFailed: {response.Data.Failed}");
                    foreach (var fail in response.Data.Failures)
                    {
                        Console.WriteLine($"\t\t: {fail}");
                    }
                }
            }
        }

        private void SendTestEmail()
        {
            var client = new SmtpClient("mail.smtp2go.com", 2525);

            client.Credentials = new NetworkCredential("keith.flowers", "7hmfQynZV8t7Ximb");

            client.Send("him@keith.flowers", "keifjd@gmail.com", "Test SMTP Client", "This is a test, just a test");
        }
    }
}
