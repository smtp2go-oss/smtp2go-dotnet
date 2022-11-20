
# SMTP2GO .NET

This .NET Standard library provides a simple way to send email via the SMTP2GO API and also access other endpoints in the API in a standard way.  Information sent and received via this service represent the same objects as the API documentation found [here](https://apidoc.smtp2go.com/documentation/#/README).

# Basic Usage
1. Add a reference to the latest Nuget package

   ```console
   Install-Package Smtp2Go.ApiClient
   ```
2. Create an `Smtp2GoApiService` providing your Smtp2Go API key...

   ```console
   var service = new Smtp2GoApiService("api-xxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
   ```
   ... or use with your preferred IOC framework.

   ```console
   .AddSingleton<IApiService, Smtp2GoApiService>(x => new Smtp2GoApiService("api-xxxxxxxxxxxxxxxxxxxxxxxxxxxxx"))
   ```
3. Create an `EmailMessage` object to send.

      ```console
   var message = new EmailMessage("From Name <from@address.email>", "To Name <to@address.email>", "alsoto@address.email");

   message.BodyHtml = "<html>Email HTML Body<html/>";
   message.BodyText = "Email Plain Text Body";

   message.AddToAddress("anotherto@address.email", "Another To Name");
   message.AddCcAddress("ccto@address.email", "Cc To Name");
   message.AddBccAddress("bccto@address.email");
   ```
4. (Optionally) add base64 encoded or local file system file attachments to the email.

   ```console
   message.AddAttachment("attachment_name.txt", "base64_attachment_data", "text/plain");
   message.AddAttachment("C:\\a_word_document.docx", "application/msword");
   ```
5. (Optionally) add base64 encoded or local file system file inline images to the email.

   ```console
   message.AddInlineImage("image_name.png", "base64_inline_image_data", "image/png");
   message.AddInlineImage("C:\\image_file.png", "image/png");
   ```  
6. (Optionally) add custom email headers.

   ```console
   message.AddCustomHeader("Reply-To", "Reply To Name <reply-to@address.email>");
   ```
7. Send the email using the API service's async `SendEmail` method. Response information will contain success and failure information along with any other identifiers returned from the Smpt2Go API.

   ```console
   var response = await service.SendEmail(message);
   ```
# Templated Emails
1. Create a `TemplatedEmailMessage` object to send.

   ```console
   var message = new TemplatedEmailMessage("TEMPLATE_ID", "From Name <from@address.email>", "To Name <to@address.email>");

   message.AddTemplateVariable("variable_name_1", "variable_value_1");
   message.AddTemplateVariable("variable_name_2", "variable_value_2");
   ```
2. (Optionally) `TemplatedEmailMessage` is an extension of the `EmailRequest` object and supports all relevant options the `EmailMessage` supports.

   ```console
   message.AddToAddress("anotherto@address.email", "Another To Name");
   message.AddBccAddress("bccto@address.email", "Bcc To Name");
   message.AddAttachment("attachment_name.txt", "base64_attachment_data", "text/plain");
   ```
3. Send the templated email using the API service's async `SendTemplatedEmail` method. Response information will contain success and failure information along with any other identifiers returned from the Smpt2Go API.

   ```console
   var response = await service.SendTemplatedEmail(message);
   ```
# Using the API Client
1. Use the underlying generic API Client to send `IApiRequest` and receive `IApiResponse` implementations to additional Smtp2Go API endpoints.

   ```console
   var apiClient = new Smtp2GoApiClient("api-xxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

   var response = await apiClient.SendReceive<EmailMessage, EmailResponse>(message, new EmailResponse(), "email/send");
   ```