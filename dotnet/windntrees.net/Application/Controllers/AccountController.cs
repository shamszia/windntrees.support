using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using DataAccess.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Abstraction.Controllers;
using Application.Services;
using Abstraction.Providers;
using DataAccess;

namespace Application.Controllers
{
    [Authorize]
    public class AccountController : BasicController
    {
        private DataAccess.DatabaseContext m_DBContext = new DataAccess.DatabaseContext();

        public UserManager<Models.User> UserManager { get; private set; }
        private RolesRepository Roles { get; set; }
        private UserRepository RepositoryUser { get; set; }

        public AccountController()
            : this(new UserManager<Models.User>(new UserStore<Models.User>(new ApplicationDbContext())))
        {
            Roles = new RolesRepository(new DatabaseContext());
            RepositoryUser = new UserRepository(new DatabaseContext());
        }

        public AccountController(UserManager<Models.User> userManager)
        {
            UserManager = userManager;
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Request.Params["response"] != null)
            {
                ViewData["Response"] = Request.Params["response"];
            }

            if (Request.QueryString["returnurl"] != null)
            {
                if (Request.QueryString["returnurl"].StartsWith("/admin"))
                {
                    return RedirectToAction("login", "auth", new { area = "admin", returnurl = returnUrl });
                }
            }
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (Session["captchaText"] != null && model.Captcha != null)
            {
                string captchatext = Session["captchaText"].ToString();
                if (model.Captcha.Equals(captchatext, StringComparison.OrdinalIgnoreCase))
                {
                    if (ModelState.IsValid)
                    {
                        var user = (new DatabaseContext()).Users.Include("Roles").Where(l => l.UserName == model.UserName).SingleOrDefault();
                        //var user = UserManager.Find(model.UserName, model.Password);
                        if (user != null)
                        {
                            if (UserManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                            {
                                if ((user.EmailConfirmed) && user.ExpiryDate > DateTime.UtcNow)
                                {
                                    List<Role> userRoles = user.Roles.ToList();
                                    if (userRoles.Count > 0)
                                    {
                                        string[] roles = userRoles.Select(l => l.RoleId).ToArray<string>();
                                        //save user roles
                                        Session["roles"] = roles;

                                        SignIn(Models.User.FromDataAccessUser(user), model.RememberMe);

                                        Session["my_account"] = user;
                                        Session["full_name"] = string.Format("{0} {1}", user.FirstName, user.LastName == null ? "" : user.LastName);
                                        Session["picture_file"] = string.Format("uploads/users/{0}", user.ImageFile == null ? "noimage.png" : user.ImageFile);
                                        try
                                        {
                                            LoginHistoryRepository attendanceRepository = new LoginHistoryRepository(new DataAccess.DatabaseContext());
                                            attendanceRepository.Create(new DataAccess.LoginHistory(Guid.NewGuid(), DateTime.UtcNow, user.UserId, HttpContext.Request.ServerVariables["REMOTE_ADDR"]));
                                        }
                                        catch { }

                                        return RedirectToLocal(returnUrl);
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("", LocaleResources.Views.Account.Login.AccountActivationError);
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", LocaleResources.Views.Account.Login.InvalidUsernamePassword);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", LocaleResources.Views.Account.Login.CaptchaError);
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", LocaleResources.Views.Account.Login.CaptchaError);
                return View(model);
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", LocaleResources.Views.Account.Login.InvalidUsernamePassword);
            return View(model);
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /**
         * 
         * New account registration and activation process starts in here.
         * 
         * **/

        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeJSONVerifierAttribute]
#else
        [ValidateJsonAntiForgeryToken]
#endif
        public async Task<JsonResult> Register([Bind(Exclude = "CreationDate, ExpiryDate, IsApproved")] Application.Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session["captchaText"] != null && model.Captcha != null)
                {
                    string captchatext = Session["captchaText"].ToString();
                    if (model.Captcha.Equals(captchatext, StringComparison.OrdinalIgnoreCase))
                    {
                        var existingUser = (new DatabaseContext()).Users.Where(l => l.UserName == model.UserName).SingleOrDefault();
                        if (existingUser != null)
                        {
                            ModelState.AddModelError("User", SharedLibrary.Resources.Global.FormMessages.RecordExists);
                        }
                        else
                        {
                            var user = new Models.User()
                            {
                                UserName = model.UserName,
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                Sex = model.Sex,
                                Title = model.Title,
                                Email = model.Email,
                                ImageFile = model.ImageFile,
                                Package = model.Package,
                                CreationDate = DateTime.UtcNow,
                                IsApproved = false,
                                EmailConfirmed = false,
                                ApprovedBy = "New Registration",
                                ExpiryDate = model.ExpiryDate
                            };

                            UserManager.UserTokenProvider = new DataProtectorTokenProvider<Models.User>(Startup.DataProtectionProvider.Create("EmailConfirmation"));

#if (MediumTrust)
                    var hashPassword = UserManager.PasswordHasher.HashPassword(model.Password);
                    string code = RequestAuthorizationCode.GenerateCode();

                    var result = RepositoryUser.Create(new DataAccess.User
                    {   
                        UserId = Guid.NewGuid().ToString(),
                        AccessFailedCount = user.AccessFailedCount,
                        ApprovedBy = user.ApprovedBy,
                        CreationDate = user.CreationDate,
                        Email = user.Email,
                        EmailConfirmed = user.EmailConfirmed,
                        ExpiryDate = user.ExpiryDate,
                        FirstName = user.FirstName,
                        IsApproved = user.IsApproved,
                        ImageFile = user.ImageFile,
                        LastName = user.LastName,
                        LockoutEnabled = false,
                        Package = user.Package,
                        PasswordHash = hashPassword,
                        SecurityStamp = code,
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                        Sex = user.Sex,
                        Title = user.Title,
                        TwoFactorEnabled = user.TwoFactorEnabled,
                        UserName = user.UserName
                    });

                    using (var newContext = new DatabaseContext())
                    {
                        var newUser = newContext.Users.Include("Roles").Where(l => l.UserId == result.UserId).SingleOrDefault();
                        var role = newContext.Roles.Where(l => l.RoleId == "mngr_myaccount").SingleOrDefault();

                        newContext.Roles.Attach(role);
                        newUser.Roles.Add(role);

                        newContext.SaveChanges();
                    }

#else
                            UserManager.EmailService = new EmailService();
                            var result = await UserManager.CreateAsync(user, model.Password);
                            if (result.Succeeded)
                            {
                                UserManager.AddToRole(user.Id, "mngr_myaccount");
                                string code = UserManager.GenerateEmailConfirmationToken(user.Id);
#endif

                                if (!string.IsNullOrEmpty(model.Email))
                                {

#if (MediumTrust)
                        var callbackUrl = Url.Action("ConfirmEmail", "Account",
                           new { userId = result.UserId, code = code }, protocol: Request.Url.Scheme).Replace("/admin", "");
#else
                                    var callbackUrl = Url.Action("ConfirmEmail", "Account",
                                       new { userId = user.Id, code = code }, protocol: Request.Url.Scheme).Replace("/admin", "");
#endif

                                    string fullname = string.Format("{0} {1}", model.FirstName, model.LastName);

                                    Models.EmailTemplates.NewAccountModel accountModel = new Models.EmailTemplates.NewAccountModel();
                                    accountModel.FullName = fullname;
                                    accountModel.Title = LocaleResources.Views.User.Index.EmailAccountActivationTitle;
                                    accountModel.ActivationLink = callbackUrl;
                                    accountModel.Company = System.Configuration.ConfigurationManager.AppSettings["Company"];
                                    accountModel.UnsubscriptionEmail = System.Configuration.ConfigurationManager.AppSettings["UnSubEmail"];

                                    string emailMessage = Util.RenderViewToString(this, "~/views/shared/emailtemplates/newaccount.cshtml", accountModel);
#if (MediumTrust)
                        try
                        {
                            EmailService.SendEmail(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["Company"], result.Email, string.Format("{0} {1}", result.FirstName, result.LastName), LocaleResources.Views.User.Index.EmailAccountActivationTitle, emailMessage);
                        }
                        catch (Exception ex)
                        {
                            MessageNotifier.notifyException(this, string.Format("{0} - {1}", model.Email, ex.Message));
                        }
#else
                                    try
                                    {
                                        UserManager.SendEmail(user.Id, LocaleResources.Views.User.Index.EmailAccountActivationSubject, emailMessage);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageNotifier.notifyException(this, string.Format("{0} - {1}", model.Email, ex.Message));
                                    }
#endif
                                }

                                return GetJSONObjectResult(user, null, false);
#if (MediumTrust)
#else
                            }
                            else
                            {
                                AddErrors(result);
                            }
#endif
                        }
                    }
                    else
                    {
                        return GetJSONObjectResultWithException(null, new Exception(LocaleResources.Views.Account.Register.CaptchaError));
                    }
                }
                else
                {
                    return GetJSONObjectResultWithException(null, new Exception(LocaleResources.Views.Account.Register.CaptchaError));
                }
            }

            //List<ObjectError> errors = new List<ObjectError>();
            //var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            //foreach (var modelStateError in modelStateErrors)
            //{
            //    errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
            //}
            //return GetObjectResult(model, errors, false);


            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            var message = "";

            foreach (var modelStateError in modelStateErrors)
            {
                message += modelStateError.ErrorMessage + Environment.NewLine;
            }

            return GetJSONObjectResultWithException(null, new Exception(message));
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult RegisterationPending()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

#if (MediumTrust)

            using (var context = new DatabaseContext())
            {
                var user = context.Users.Where(l => l.UserId == userId).SingleOrDefault();
                if (user != null)
                {
                    if (user.SecurityStamp.Equals(code))
                    {
                        user.EmailConfirmed = true;
                        //rewrite the stamp for denying same link authorization.
                        user.SecurityStamp = RequestAuthorizationCode.GenerateCode();
                        context.SaveChanges();

                        return View("RegisterationConfirmed");
                    }
                }
            }

#else
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<Models.User>(Startup.DataProtectionProvider.Create("EmailConfirmation"))
            {
                TokenLifespan = TimeSpan.FromHours(6)
            };

            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                return View("RegisterationConfirmed");
            }
            AddErrors(result);
#endif

            return View("RegisterationFailed");
        }

        [AllowAnonymous]
        public ActionResult RegisterationConfirmed()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterationFailed()
        {
            return View();
        }

        /*
         * Password reset functionality starts from here.
         * 
         * */
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmationEmailSent()
        {
            return View("resetpasswordemailsent");
        }

        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public async Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                string userid = null;
                string email = null;
                string fullname = null;

                using (var dbContext = new DataAccess.DatabaseContext())
                {
                    var existingUser = dbContext.Users.SingleOrDefault(s => s.UserName == model.UserName);
                    if (existingUser != null)
                    {
                        userid = existingUser.UserId;
                        email = existingUser.Email;
                        fullname = string.Format("{0} {1}", existingUser.FirstName, existingUser.LastName);
                    }
                }

                if (!string.IsNullOrEmpty(email))
                {   
                    UserManager.UserTokenProvider = new DataProtectorTokenProvider<Models.User>(Startup.DataProtectionProvider.Create("EmailConfirmation"))
                    {
                        TokenLifespan = TimeSpan.FromHours(6)
                    };
                    UserManager.EmailService = new EmailService();

                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(userid);

                    var callbackUrl = Url.Action("ResetPasswordConfirm", "Account",
                                       new { userId = userid, code = code }, protocol: Request.Url.Scheme);

                    Models.EmailTemplates.ResetPasswordModel resetModel = new Models.EmailTemplates.ResetPasswordModel();
                    resetModel.FullName = fullname;
                    resetModel.Title = "Reset Password";
                    resetModel.ActivationLink = callbackUrl;
                    resetModel.Company = System.Configuration.ConfigurationManager.AppSettings["Company"];
                    resetModel.UnsubscriptionEmail = System.Configuration.ConfigurationManager.AppSettings["UnSubEmail"];
                    string emailMessage = Util.RenderViewToString(this, "~/views/shared/emailtemplates/resetpassword.cshtml", resetModel);

                    await UserManager.SendEmailAsync(userid,
                                        "Reset Password",
                                        emailMessage);

                    return RedirectToAction("resetpending");
                }
                return View("resetfailed");
            }
            ModelState.AddModelError("", LocaleResources.Views.Account.ResetPassword.UsernameError);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPending()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetFailed()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirm(string userId, string code)
        {
            ResetPasswordConfirmModel model = new ResetPasswordConfirmModel() { UserId = userId, Token = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public async Task<ActionResult> ResetPasswordConfirm(ResetPasswordConfirmModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserId == null || model.Token == null)
                {
                    return View("ResetFailed");
                }

                UserManager.UserTokenProvider = new DataProtectorTokenProvider<Models.User>(Startup.DataProtectionProvider.Create("EmailConfirmation"))
                {
                    TokenLifespan = TimeSpan.FromHours(6)
                };
                var result = await UserManager.ConfirmEmailAsync(model.UserId, model.Token);
                try
                {
                    if (result.Succeeded)
                    {
                        IdentityResult removePasswordResult = await UserManager.RemovePasswordAsync(model.UserId);
                        if (removePasswordResult.Succeeded)
                        {
                            IdentityResult addPasswordResult = await UserManager.AddPasswordAsync(model.UserId, model.NewPassword);
                            if (addPasswordResult.Succeeded)
                            {

                                return RedirectToAction("login", new { response = LocaleResources.Views.Account.ResetPasswordConfirm.Success });
                            }
                        }
                        return RedirectToAction("login", new { response = LocaleResources.Views.Account.ResetPasswordConfirm.ResetFailed });
                    }
                }
                catch
                {
                    return RedirectToAction("login", new { response = LocaleResources.Views.Account.ResetPasswordConfirm.ResetFailed });
                }
            }
            ModelState.AddModelError("", LocaleResources.Views.Account.ResetPasswordConfirm.NotEqual);
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
#if (MediumTrust)
        [RequestAuthorizationCodeVerifier]
#else
        [ValidateAntiForgeryToken]
#endif
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new Models.User() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
//#if (MediumTrust)
//        [RequestAuthorizationCodeVerifier]
//#else
//        [ValidateAntiForgeryToken]
//#endif    
        public ActionResult LogOff()
        {
            Session.Clear();

            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(Models.User user, bool isPersistent)
        {
#if (MediumTrust)
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, DefaultAuthenticationTypes.ApplicationCookie));
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
#else
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
#endif
        }

        private void SignIn(Models.User user, bool isPersistent)
        {
#if (MediumTrust)
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, DefaultAuthenticationTypes.ApplicationCookie));
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
#else
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
#endif
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
#endregion

    }
}
