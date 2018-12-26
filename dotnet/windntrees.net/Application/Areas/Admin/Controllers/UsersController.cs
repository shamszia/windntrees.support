using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using WebMatrix.WebData;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Application.Models;
using Abstraction.Controllers;
using Abstraction.Results;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;
using Application.Services;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class UsersController : CRUDController<DataAccess.User>
    {
        public UserManager<Models.User> UserManager { get; private set; }
        private RolesRepository Roles { get; set; }
        private UserRepository RepositoryUser { get; set; }

        public UsersController(UserManager<Models.User> manager)
        {
            UserManager = manager;
        }

        public UsersController()
            : this(new UserManager<Models.User>(new UserStore<Models.User>(new ApplicationDbContext())))
        {
            Roles = new RolesRepository(((DatabaseContext)DBContext));
            RepositoryUser = new UserRepository(new DatabaseContext());

            DBContext.Configuration.LazyLoadingEnabled = true;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<DataAccess.User> GetRepository()
        {
            RepositoryContent = new UserRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Create([Bind(Exclude = "CreationDate")] DataAccess.User model)
        {
            if (ModelState.IsValid)
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
                        IsApproved = model.IsApproved,
                        EmailConfirmed = model.EmailConfirmed,
                        ApprovedBy = User.Identity.Name,
                        ExpiryDate = model.ExpiryDate
                    };

                    model.CreationDate = user.CreationDate;
                    model.ApprovedBy = user.ApprovedBy;

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
                    var result = UserManager.Create(user, model.Password);
                    if (result.Succeeded)
                    {
                        
                    model.UserId = user.Id;
                    UserManager.AddToRole(user.Id, "mngr_myaccount");

                    //update the user model to return role additions.
                    model.Roles.Add(new Role { RoleId = "mngr_myaccount", Name = "mngr_myaccount" });

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

                    model.PasswordHash = string.Empty;
                    model.SecurityStamp = string.Empty;

                    //return user object after conversion
                    return GetObjectResult(model, null, false);
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

            List<ObjectError> errors = new List<ObjectError>();

            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            foreach (var modelStateError in modelStateErrors)
            {
                errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
            }

            return GetObjectResult(model, errors, false);
        }

        public override JsonResult Update([Bind(Exclude = "Password,ConfirmPassword")] DataAccess.User model)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var existingUser = dbContext.Users.Include("Roles").Single(s => s.UserId == model.UserId);

                    var passwordHash = existingUser.PasswordHash;
                    var securityStamp = existingUser.SecurityStamp;
                    var phone = existingUser.PhoneNumber;
                    var phoneConfirmed = existingUser.PhoneNumberConfirmed;
                    var twoFactorEnabled = existingUser.TwoFactorEnabled;
                    var lockoutEndDateUtc = existingUser.LockoutEndDateUtc;
                    var lockoutEnabled = existingUser.LockoutEnabled;
                    var accessFailedCount = existingUser.AccessFailedCount;

                    dbContext.Entry(existingUser).CurrentValues.SetValues(model);

                    existingUser.PasswordHash = passwordHash;
                    existingUser.SecurityStamp = securityStamp;
                    existingUser.PhoneNumber = phone;
                    existingUser.PhoneNumberConfirmed = phoneConfirmed;
                    existingUser.TwoFactorEnabled = twoFactorEnabled;
                    existingUser.LockoutEndDateUtc = lockoutEndDateUtc;
                    existingUser.LockoutEnabled = lockoutEnabled;
                    existingUser.AccessFailedCount = accessFailedCount;

                    foreach (var existingRole in existingUser.Roles.ToList())
                    {
                        if (!model.Roles.Any(c => c.RoleId == existingRole.RoleId))
                        {
                            existingUser.Roles.Remove(existingRole);
                        }
                    }

                    foreach (var role in model.Roles)
                    {
                        if (!existingUser.Roles.Any(c => c.RoleId == role.RoleId))
                        {
                            var userRole = new Role { RoleId = role.RoleId, Name = role.Name };
                            dbContext.Roles.Attach(userRole);
                            existingUser.Roles.Add(userRole);
                        }
                    }

                    dbContext.SaveChanges();

                    existingUser.PasswordHash = string.Empty;
                    existingUser.SecurityStamp = string.Empty;

                    return GetObjectResult(existingUser, null, false);
                }
            }

            List<ObjectError> errors = new List<ObjectError>();

            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            foreach (var modelStateError in modelStateErrors)
            {
                errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
            }

            return GetObjectResult(model, errors, false);
        }

        public override JsonResult Delete(DataAccess.User userModel)
        {
            if (ModelState.IsValid)
            {
                if (userModel.UserName.Equals("webadmin", StringComparison.OrdinalIgnoreCase))
                {

                    return GetObjectResultWithException(userModel, new Exception(GetStandardExceptionMessage()));
                }
                else
                {
                    Repository.Delete(userModel);

                    userModel.PasswordHash = string.Empty;
                    userModel.SecurityStamp = string.Empty;

                    return GetObjectResult(userModel, null, false);
                }
            }

            List<ObjectError> errors = new List<ObjectError>();

            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            foreach (var modelStateError in modelStateErrors)
            {
                errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
            }

            return GetObjectResult(userModel, errors, false);
        }

        public JsonResult ChangePassword(Application.Models.LocalPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            var message = "";

            foreach (var modelStateError in modelStateErrors)
            {
                message += modelStateError.ErrorMessage + Environment.NewLine;
            }
            return Json(new { success = false, response = message });
        }

        public JsonResult GetPackagesList()
        {
            var packages = new string[] { "Package1", "Package2", "Package3" };
            return Json(packages, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableRoles()
        {
            var roles = Roles.GetAllRoles();
            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        protected override string GetFolderPath()
        {
            return "~/uploads/users/";
        }

        protected override Boolean SaveFile(Object recordId, string fileName, String uploadType = null)
        {
            try
            {
                var record = Repository.Get(recordId);
                record.ImageFile = fileName;
                Repository.Update(record);

                return true;
            }
            catch (Exception ex)
            {
                MessageNotifier.notifyException(this, ex.Message);
            }

            return false;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
