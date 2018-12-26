using System;
using System.Web.Mvc;
using Abstraction.Controllers;
using Application.Captcha;
using Abstraction.Providers;

namespace Application.Controllers
{
    public class GeneralController : BasicController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        [HttpPost]
#if (MediumTrust)
        [RequestAuthorizationCodeJSONVerifierAttribute]
#else
        [ValidateJsonAntiForgeryToken]
#endif  
        public JsonResult SendEmail(Models.GeneralEmail emailModel)
        {
            if (ModelState.IsValid)
            {
                if (Session["captchaText"] != null && emailModel.Captcha != null)
                {
                    string captchatext = Session["captchaText"].ToString();
                    if (emailModel.Captcha.Equals(captchatext, StringComparison.OrdinalIgnoreCase))
                    {
                        string toEmailAddress = System.Configuration.ConfigurationManager.AppSettings["ToEmail"];
                        string contactPerson = System.Configuration.ConfigurationManager.AppSettings["Company"];

                        if (!string.IsNullOrEmpty(toEmailAddress))
                        {
                            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient();
                            System.Net.Mail.MailAddress fromEmail = new System.Net.Mail.MailAddress(emailModel.FromEmail, emailModel.FromName);
                            System.Net.Mail.MailAddress toEmail = new System.Net.Mail.MailAddress(toEmailAddress, contactPerson);

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
                }
            }
            return GetJSONObjectResult(emailModel, GetStandardErrorLocaleMessage(), true);
        }

        public ActionResult GenerateCaptcha()
        {
            try
            {
                var capchaName = Guid.NewGuid().ToString() + ".png";

                CaptchaImage capchaImage = new CaptchaImage(150, 50, new System.Drawing.FontFamily("Arial"));
                //string text = capchaImage.CreateRandomText(4) + capchaImage.CreateRandomText(3);
                string text = capchaImage.CreateRandomText(4);
                capchaImage.SetText(text);
                capchaImage.GenerateImage();
                capchaImage.Image.Save(Server.MapPath("~/uploads/captchas/") + capchaName, System.Drawing.Imaging.ImageFormat.Png);

                Session["captchaText"] = text;

                return Json(capchaName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                MessageNotifier.notifyException(this, ex.Message);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
