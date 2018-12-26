using Abstraction.Core.Controllers;
using Application.Core.Models.Configuration;
using DataAccess.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace Application.Core.Controllers
{
    public class GeneralController : BasicController
    {
        private ApplicationSettings applicationSettings;

        public GeneralController(IOptions<ApplicationSettings> options)
        {
            applicationSettings = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendEmail([FromBody] Email emailModel)
        {
            if (ModelState.IsValid)
            {
                string recipientAddress = applicationSettings.ToEmail;                

                if (!string.IsNullOrEmpty(recipientAddress))
                {
                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(applicationSettings.EmailHost, applicationSettings.EmailHostPort);
                    mailClient.Credentials = new System.Net.NetworkCredential(applicationSettings.EmailUser, applicationSettings.EmailUserPassword);

                    System.Net.Mail.MailAddress fromEmail = new System.Net.Mail.MailAddress(emailModel.FromEmail, emailModel.FromName);
                    System.Net.Mail.MailAddress toEmail = new System.Net.Mail.MailAddress(recipientAddress, recipientAddress);

                    System.Net.Mail.MailMessage clientMessage = new System.Net.Mail.MailMessage(fromEmail, toEmail);
                    clientMessage.Subject = emailModel.Subject;
                    clientMessage.Body = emailModel.Message;

                    try
                    {
                        mailClient.Send(clientMessage);
                    }
                    catch (Exception ex)
                    {
                        MessageNotifier.notifyException(this, ex.Message);
                        return GetJSONObjectResultWithException(emailModel, ex);
                    }

                    return GetJSONObjectResult(emailModel, null, true);
                }
            }

            return GetJSONObjectResult(emailModel, GetStandardErrorLocaleMessage(), true);
        }
    }
}
