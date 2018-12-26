using Application.Core.Models.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private ApplicationSettings applicationSettings;

        public EmailSender(IOptions<ApplicationSettings> options)
        {
            applicationSettings = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(applicationSettings.EmailHost, applicationSettings.EmailHostPort);
            mailClient.Credentials = new System.Net.NetworkCredential(applicationSettings.EmailUser, applicationSettings.EmailUserPassword);

            System.Net.Mail.MailMessage emailMessage = new System.Net.Mail.MailMessage(applicationSettings.FromEmail, email);
            emailMessage.Subject = subject;
            emailMessage.Body = message;

            mailClient.Send(emailMessage);

            return Task.CompletedTask;
        }
    }
}
