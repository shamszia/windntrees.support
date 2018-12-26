using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Abstraction.Filters;
using DataAccess;
using Abstraction.Controllers;
using Abstraction.Results;
using System.Data.Entity;
using Abstraction.Repository;
using DataAccess.Repositories;
using Abstraction.Providers;

namespace Application.Areas.MyAccount.Controllers
{
    [Authorize(Roles = "mngr_myaccount")]
    public class HomeController : CRUDController<LoginHistory>
    {
        private UserRepository RepositoryUser { get; set; }

        public HomeController()
        {
            RepositoryUser = new UserRepository(new DatabaseContext());
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<LoginHistory> GetRepository()
        {
            RepositoryContent = new LoginHistoryRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }

        public override JsonResult Find(SearchFilter searchQuery)
        {
            string userid = ((DatabaseContext)DBContext).Users.SingleOrDefault(p => p.UserName == User.Identity.Name).UserId;
            searchQuery.key = userid;

            return base.Find(searchQuery);
        }

        protected override Boolean SaveFile(Object recordId, string fileName, string uploadType = null)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var profile = context.Users.Where(l => l.UserName == User.Identity.Name).SingleOrDefault();
                    profile.ImageFile = fileName;

                    context.Users.Attach(profile);
                    context.Entry(profile).State = EntityState.Modified;

                    context.SaveChanges();
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
#if (MediumTrust)
        [RequestAuthorizationCodeJSONVerifierAttribute]
#else
        [ValidateJsonAntiForgeryToken]
#endif
        public JsonResult UpdateProfile(DataAccess.UserEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new DatabaseContext())
                    {
                        var profile = context.Users.Where(l => l.UserId == model.UserId).SingleOrDefault();

                        profile.FirstName = model.FirstName;
                        profile.LastName = model.LastName;
                        profile.Sex = model.Sex;
                        profile.Title = model.Title;
                        profile.ImageFile = model.ImageFile;
                        profile.Email = model.Email;

                        context.Users.Attach(profile);
                        context.Entry(profile).State = EntityState.Modified;

                        context.SaveChanges();

                        var responseObject = new
                        {
                            UserId = profile.UserId,
                            FirstName = profile.FirstName,
                            LastName = profile.LastName,
                            Sex = profile.Sex,
                            Title = profile.Title,
                            ImageFile = profile.ImageFile,
                            Email = profile.Email
                        };

                        return GetJSONObjectResult(responseObject, null, true, RequestAuthorizationCode.GenerateCode(Request));
                    }
                }

                List<ObjectError> errors = new List<ObjectError>();

                var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
                foreach (var modelStateError in modelStateErrors)
                {
                    errors.Add(new ObjectError("exception", modelStateError.ErrorMessage));
                }

                return GetJSONObjectResult(model, errors, false, RequestAuthorizationCode.GenerateCode(Request));
            }
            catch (Exception ex)
            {
                return GetJSONObjectResultWithException(null, ex, "", false, RequestAuthorizationCode.GenerateCode(Request));
            }
        }

        public JsonResult GetProfile()
        {
            try
            {
                var profile = new DatabaseContext().Users.Where(l => l.UserName == User.Identity.Name).SingleOrDefault();

                var profileResponseObject = new
                {
                    UserId = profile.UserId,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Sex = profile.Sex,
                    Title = profile.Title,
                    ImageFile = profile.ImageFile,
                    Package = profile.Package,
                    Email = profile.Email
                };

                return GetJSONObjectResult(profileResponseObject, null, true, RequestAuthorizationCode.GenerateCode(Request));
            }
            catch (Exception ex)
            {
                return GetJSONObjectResultWithException(null, ex, "", false, RequestAuthorizationCode.GenerateCode(Request));
            }
        }
    }
}
