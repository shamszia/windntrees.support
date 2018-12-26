using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using Application.Core.Data;
using Application.Core.Models;
using Application.Core.Models.AccountViewModels;
using Application.Core.Services;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Abstraction.Core.Results;
using Microsoft.Extensions.Options;
using Application.Core.Models.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DataAccess.Core.Models;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class UsersController : CRUDController<ApplicationUser>
    {
        private UserManager<ApplicationUser> ManagerUser { get; set; }
        private RoleManager<IdentityRole> ManagerRole { get; set; }
        private SignInManager<ApplicationUser> ManagerSignIn { get; set; }
        private IEmailSender EmailSender { get; set; }
        private ILogger<UsersController> _logger { get; set; }
        private ApplicationSettings applicationSettings { get; set; }
        private IOptions<ApplicationSettings> _settingsOptions;

        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<UsersController> logger,
            IOptions<ApplicationSettings> options)
        {
            ManagerUser = userManager;
            ManagerRole = roleManager;
            ManagerSignIn = signInManager;
            EmailSender = emailSender;
            _logger = logger;
            _settingsOptions = options;
            applicationSettings = options.Value;


            FilesExtensionsLimit = applicationSettings.AllowedExtensions;
            FileLengthLimit = int.Parse(applicationSettings.MaxFileSizeInKB);

            RootPath = Startup.ENV.WebRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            //return new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), ManagerUser, ManagerRole, EmailSender, _logger, _settingsOptions);
            return new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        protected override ContentRepository<ApplicationUser> GetRepository()
        {
            RepositoryContent = new ApplicationUserRepository((ApplicationDbContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Create([FromBody] ApplicationUser model)
        {
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return GetObjectResult(model, GetModelStateErrors(), false);
            }
            else
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    if (ModelState.IsValid)
                    {
                        var existingUser = (new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>())).Users.Where(l => l.UserName == model.UserName).SingleOrDefault();
                        if (existingUser != null)
                        {
                            ModelState.AddModelError("User", SharedLibrary.Core.Resources.Global.FormMessages.RecordExists);
                        }
                        else
                        {
                            model.CreationDate = DateTime.UtcNow;
                            model.ApprovedBy = User.Identity.Name;

                            List<IdentityUserRole<string>> roles = new List<IdentityUserRole<string>>(model.Roles.ToArray<IdentityUserRole<string>>());

                            model.Roles.Clear();

                            //passwordhash will be treated as string password here.
                            var result = ManagerUser.CreateAsync(model, model.Password).Result;

                            if (result.Succeeded)
                            {
                                _logger.LogInformation("User created a new account with password.");

                                //RepositoryUserRoles.RemoveUserRoles(user.Id);

                                var RepositoryUserRoles = new IdentityUserRoleRepository(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
                                RepositoryUserRoles.AddUserRoles(model.Id, roles.Select(l => l.RoleId).ToArray<string>());

                                //foreach (var role in roles.Select(l => l.RoleId).ToList<string>())
                                //{
                                //    ManagerUser.AddToRoleAsync(model, role.ToUpper());
                                //    _logger.LogInformation(string.Format("User [{0}] role [{1}] added.", model.UserName, role.ToUpper()));
                                //}

                                var code = ManagerUser.GenerateEmailConfirmationTokenAsync(model).Result;

                                var callbackUrl = Url.EmailConfirmationLink(model.Id, code, Request.Scheme);

                                try
                                {
                                    //string emailMessage = Util.RenderViewToString(this, "~/views/shared/emailtemplates/newaccount.cshtml", accountModel);
                                    EmailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                                }
                                catch (Exception ex)
                                {

                                    MessageNotifier.notifyException(this, string.Format("{0} - {1}", model.Email, ex.Message));
                                }

                                try
                                {
                                    ActivityHistoryRepository attendanceRepository = new ActivityHistoryRepository(new ApplicationContext());
                                    attendanceRepository.Create(new ActivityHistory
                                    {
                                        Uid = Guid.NewGuid(),
                                        ActivityTime = DateTime.UtcNow,
                                        Activity = "new admin-registration",
                                        Request = HttpContext.Request.Path,
                                        UserId = model.Id,
                                        Ipaddress = string.Format("{0}:{1}", HttpContext.Connection.RemoteIpAddress, HttpContext.Connection.RemotePort)
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageNotifier.notifyException(this, string.Format("{0} - {1}", model.Email, ex.Message));
                                }

                                _logger.LogInformation("User created a new account with password.");

                                model.PasswordHash = string.Empty;
                                model.SecurityStamp = string.Empty;

                                //return user object after conversion
                                return GetObjectResult(model, null, false);
                            }
                            else
                            {   
                                foreach(var error in result.Errors)
                                {
                                    ModelState.AddModelError(error.Code, error.Description);
                                }
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", string.Format(SharedLibrary.Core.Resources.Global.ValidationMessages.Compare, "Password", "ConfirmPassword"));
                    }
                }
            }
            return GetObjectResult(model, GetModelStateErrors(), false);
        }

        public override JsonResult Update([FromBody] ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                List<IdentityUserRole<string>> roles = new List<IdentityUserRole<string>>(model.Roles.ToArray<IdentityUserRole<string>>());
                //remove roles before updating user model.
                model.Roles.Clear();

                var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
                var user = context.Users.Where(l => l.UserName == model.UserName).SingleOrDefault();
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Sex = model.Sex;
                    user.Title = model.Title;
                    user.Email = model.Email;
                    user.Package = model.Package;
                    user.ExpiryDate = model.ExpiryDate;
                    user.IsApproved = model.IsApproved;
                    user.EmailConfirmed = model.EmailConfirmed;
                }

                if (context.SaveChanges() > 0)
                {
                    //var user1 = ManagerUser.FindByNameAsync(model.UserName).Result;
                    var RepositoryUserRoles = new IdentityUserRoleRepository(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));

                    RepositoryUserRoles.RemoveUserRoles(user.Id);
                    RepositoryUserRoles.AddUserRoles(user.Id, roles.Select(l => l.RoleId).ToArray<string>());
                }

                //update model for updated response with roles.
                model.Roles = roles;
                return GetObjectResult(model, null, false);
            }

            return GetObjectResult(model, GetModelStateErrors(), false);
        }

        public override JsonResult Delete([FromBody] ApplicationUser model)
        {
            if (model.Email.Equals(applicationSettings.AdminEmail, StringComparison.OrdinalIgnoreCase))
            {
                return GetObjectResultWithException(model, new Exception(GetStandardExceptionMessage()));
            }
            else
            {
                var user = ManagerUser.FindByNameAsync(model.UserName).Result;
                var result = ManagerUser.DeleteAsync(user).Result;

                if (result.Succeeded)
                {
                    model.PasswordHash = string.Empty;
                    model.SecurityStamp = string.Empty;

                    return GetObjectResult(model, null, false);
                }
                else
                {
                    return GetObjectResultWithException(model, new Exception(SharedLibrary.Core.Resources.Global.ValidationMessages.DeletionFailure));
                }
            }
        }

        protected override bool SaveUpload(object recordId, string fileName, string uploadType = null)
        {
            try
            {
                var record = Repository.Get(recordId);
                record.ImageFile = fileName;


                Repository.Update(record, recordId);

                return true;
            }
            catch (Exception ex)
            {
                MessageNotifier.notifyException(this, ex.Message);
            }

            return false;
        }

        public JsonResult ChangePassword([FromBody] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = ManagerUser.FindByNameAsync(User.Identity.Name).Result;

                    if (user != null)
                    {
                        ManagerUser.RemovePasswordAsync(user);
                        ManagerUser.AddPasswordAsync(user, model.Password);

                        return GetJSONObjectResult(new { User = User.Identity.Name, Result = true }, null, false);
                    }
                }
                catch
                {
                }

                model.Password = string.Empty;
                model.ConfirmPassword = string.Empty;

                return GetJSONObjectResultWithException(model, new Exception(GetStandardExceptionMessage()));
            }

            model.Password = string.Empty;
            model.ConfirmPassword = string.Empty;

            return GetJSONObjectResult(model, GetModelStateErrors(), false);
            
        }

        public JsonResult GetPackagesList()
        {
            var packages = new string[] { "Package1", "Package2", "Package3" };

            return GetJSONObjectResult(packages, null, false);
        }

        public JsonResult GetAvailableRoles()
        {
            var roles = ManagerRole.Roles.ToList();

            return GetJSONObjectResult(roles, null, false);
        }
    }
}
