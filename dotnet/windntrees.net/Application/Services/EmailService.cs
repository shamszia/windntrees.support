using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendEmailAsync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task SendEmailAsync(IdentityMessage message)
        {
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailAddress fromEmail = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["Company"]);
            System.Net.Mail.MailAddress toEmail = new System.Net.Mail.MailAddress(message.Destination);

            System.Net.Mail.MailMessage clientMessage = new System.Net.Mail.MailMessage(fromEmail, toEmail);
            clientMessage.Subject = "Activate Account";
            clientMessage.Body = message.Body;
            clientMessage.IsBodyHtml = true;

            await mailClient.SendMailAsync(clientMessage);
        }

        public static void SendEmail(string from, string fromTitle, string to, string toTitle, string subject, string message)
        {
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient();
            //System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["Company"], message.Destination
            System.Net.Mail.MailAddress fromEmail = new System.Net.Mail.MailAddress(from, fromTitle);
            System.Net.Mail.MailAddress toEmail = new System.Net.Mail.MailAddress(to, toTitle);

            System.Net.Mail.MailMessage clientMessage = new System.Net.Mail.MailMessage(fromEmail, toEmail);
            clientMessage.Subject = subject;
            clientMessage.Body = message;
            clientMessage.IsBodyHtml = true;

            mailClient.Send(clientMessage);
        }
    }
}