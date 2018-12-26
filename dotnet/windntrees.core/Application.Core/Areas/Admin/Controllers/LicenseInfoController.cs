using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class LicenseInfoController : CRUDController<LicenseInfo>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<LicenseInfo> GetRepository()
        {
            RepositoryContent = new LicenseInfoRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Update([FromBody] LicenseInfo contentObject)
        {
            var licenseInfo = ((ApplicationContext)DBContext).LicenseInfo.Where(l => l.ProductId == contentObject.ProductId).SingleOrDefault();

            if (licenseInfo == null)
            {
                return base.Create(contentObject);
            }
            else
            {
                licenseInfo.Code = contentObject.Code;
                return base.Update(licenseInfo);
            }
        }
    }
}