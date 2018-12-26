using Abstraction.Core.Controllers;
using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using Abstraction.Core.Results;
using Application.Core.Data;
using Application.Core.Models;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Areas.MyAccount.Controllers
{
    [Area("MyAccount")]
    [Authorize(Roles = "mngr_myaccount")]
    public class HomeController : CRUDController<ActivityHistory>
    {
        private UserManager<ApplicationUser> ManagerUser { get; set; }

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            ManagerUser = userManager;

            RootPath = Startup.ENV.WebRootPath;
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<ActivityHistory> GetRepository()
        {
            RepositoryContent = new ActivityHistoryRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyProfile()
        {
            return View();
        }

        public override JsonResult Find([FromBody] SearchFilter searchQuery)
        {
            Task<ApplicationUser> userTask = ManagerUser.FindByNameAsync(User.Identity.Name);
            while (!userTask.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }
            ApplicationUser user = userTask.Result;

            if (user != null)
            {
                searchQuery.key = user.Id;
            }

            return base.Find(searchQuery);
        }

        protected override bool SaveUpload(Object recordId, string fileName, string uploadType = null)
        {
            try
            {
                //Task<ApplicationUser> userTask = ManagerUser.FindByNameAsync(User.Identity.Name);
                //while (!userTask.IsCompleted)
                //{
                //    System.Threading.Thread.Sleep(10);
                //}
                //ApplicationUser user = userTask.Result;

                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    var user = context.Users.Where(l => l.UserName == User.Identity.Name).SingleOrDefault();

                    if (user != null)
                    {
                        user.ImageFile = fileName;

                        context.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageNotifier.notifyException(this, ex.Message);
            }

            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateProfile([FromBody] UserEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Task<ApplicationUser> userTask = ManagerUser.FindByNameAsync(User.Identity.Name);
                    //while (!userTask.IsCompleted)
                    //{
                    //    System.Threading.Thread.Sleep(10);
                    //}
                    //ApplicationUser user = userTask.Result;

                    var repository = new ApplicationUserRepository(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
                    var contextUser = repository.GetByName(User.Identity.Name);
                    if (contextUser != null)
                    {
                        contextUser.FirstName = model.FirstName;
                        contextUser.LastName = model.LastName;
                        contextUser.Sex = model.Sex;
                        contextUser.Title = model.Title;
                        contextUser.ImageFile = model.ImageFile;
                        contextUser.Email = model.Email;

                        repository.Update(contextUser);
                    }

                    return GetJSONObjectResult(model, null, true);
                }

                List<ObjectError> errors = new List<ObjectError>();

                var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
                foreach (var modelStateError in modelStateErrors)
                {
                    errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
                }

                return GetJSONObjectResult(model, errors, false);
            }
            catch (Exception ex)
            {
                return GetJSONObjectResultWithException(null, ex, "", false);
            }
        }

        public JsonResult GetProfile()
        {
            try
            {
                Task<ApplicationUser> userTask = ManagerUser.FindByNameAsync(User.Identity.Name);
                while (!userTask.IsCompleted)
                {
                    System.Threading.Thread.Sleep(10);
                }
                ApplicationUser user = userTask.Result;

                var profileResponseObject = new
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Sex = user.Sex,
                    Title = user.Title,
                    ImageFile = user.ImageFile,
                    Package = user.Package,
                    Email = user.Email
                };

                return GetJSONObjectResult(profileResponseObject, null, true);
            }
            catch (Exception ex)
            {
                return GetJSONObjectResultWithException(null, ex, "", false);
            }
        }
    }
}
