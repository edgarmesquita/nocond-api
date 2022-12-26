using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoCond.Application.Email.Models;
using NoCond.Application.Email.Services;
using NoCond.Application.Email.Services.Interfaces;
using NoCond.Application.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;
using EmailAddress = SendGrid.Helpers.Mail.EmailAddress;

namespace NoCond.Infrastructure.Services
{
    /// <summary>
    /// E-mail Sender Service
    /// </summary>
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SendGridSettings _settings;

        /// <summary>
        /// EmailSenderService
        /// </summary>
        /// <param name="settings"></param>
        public EmailSenderService(SendGridSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SendAsync(EmailRequest request)
        {
            var apiKey = System.Environment.GetEnvironmentVariable(_settings.ApiKey);
            var client = new SendGridClient(apiKey);

            await SendAsync(client, request);
        }

        private async Task SendAsync(SendGridClient client, EmailRequest request)
        {
            var msg = new SendGridMessage
            {
                From = request.FromAddress == null ?
                    new EmailAddress(_settings.FromAddress, _settings.FromName) :
                    new EmailAddress(request.FromAddress.Email, request.FromAddress.Name),
                Subject = request.Subject
            };

            msg.AddTos(request.ToAddresses.Select(o =>
                new EmailAddress(o.Email, o.Name)).ToList());

            msg.AddCcs(request.CcAddresses.Select(o =>
                new EmailAddress(o.Email, o.Name)).ToList());

            msg.AddBccs(request.BccAddresses.Select(o =>
                new EmailAddress(o.Email, o.Name)).ToList());

            if (!string.IsNullOrEmpty(request.TemplateCode))
            {
                msg.SetTemplateId(request.TemplateCode);
                msg.SetTemplateData(request.TemplateParameters);
            }
            await client.SendEmailAsync(msg);
        }
        
        /// <summary>
        /// Send list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SendListAsync(EmailRequest[] request)
        {
            var apiKey = System.Environment.GetEnvironmentVariable(_settings.ApiKey);
            var client = new SendGridClient(apiKey);

            foreach (var emailRequest in request)
            {
                await SendAsync(client, emailRequest);
            }
        }
    }
}