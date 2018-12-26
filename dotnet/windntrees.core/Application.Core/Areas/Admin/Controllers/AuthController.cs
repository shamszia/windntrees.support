using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Abstraction.Controllers;
using System.Security.Claims;
using System.Security.Principal;
using Abstraction.Providers;

namespace Application.Core.Areas.Admin.Controllers
{
    [Authorize]
    public class AuthController : BasicController
    {
        private ApplicationContext m_DBContext = new ApplicationContext();

        public UserManager<Models.User> UserManager { get; private set; }

        public AuthController()
            : this(new UserManager<Models.User>(new UserStore<Models.User>(new ApplicationDbContext())))
        {
        }

        public AuthController(UserManager<Models.User> userManager)
        {
            UserManager = userManager;
        }

        //
        // GET: /Admin/

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Admin/

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
                        var user = (new ApplicationContext()).Users.Where(l => l.UserName == model.UserName).SingleOrDefault();
                        if (user != null)
                        {
                            if (UserManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                            {
                                if (((user.IsApproved == null) ? false : (bool)user.IsApproved) && user.ExpiryDate > DateTime.UtcNow)
                                {
                                    List<Role> userRoles = user.Roles.ToList();

                                    if (userRoles.Count > 0)
                                    {
                                        //Name attribute of the Role entity describes the role name.
                                        string[] roles = userRoles.Select(l => l.Name).ToArray<string>();
                                        Session["roles"] = roles; //Navigation composer requires roles list.

                                        SignIn(Models.User.FromDataAccessUser(user), model.RememberMe);

                                        Session["my_account"] = user;
                                        Session["full_name"] = string.Format("{0} {1}", user.FirstName, user.LastName);
                                        Session["picture_file"] = string.Format("uploads/users/{0}", user.ImageFile);

                                        try
                                        {
                                            LoginHistoryRepository attendanceRepository = new LoginHistoryRepository(new DataAccess.ApplicationContext());
                                            attendanceRepository.Create(new DataAccess.LoginHistory(Guid.NewGuid(), DateTime.UtcNow, user.UserId, HttpContext.Request.ServerVariables["REMOTE_ADDR"]));
                                        }
                                        catch { }

                                        return RedirectToLocal(returnUrl);
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("", LocaleResources.Core.Views.Login.Index.AccountActivationErrorD);
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", LocaleResources.Core.Views.Login.Index.InvalidUsernamePasswordD);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", LocaleResources.Core.Views.Login.Index.CaptchaErrorD);
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", LocaleResources.Core.Views.Login.Index.CaptchaErrorD);
                return View(model);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", LocaleResources.Core.Views.Login.Index.InvalidUsernamePasswordD);
            return View(model);
        }

        //[HttpPost]
        //[AuthorizationCodeVerifier]
        public ActionResult LogOff()
        {
            Session.Clear();

            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
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

        private void SignIn(Models.User user, bool isPersistent)
        {
#if (MediumTrust)
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, DefaultAuthenticationTypes.ApplicationCookie));
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
#else
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
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
