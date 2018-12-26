using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class LicenseInfoController : CRUDController<LicenseInfo>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<LicenseInfo> GetRepository()
        {
            RepositoryContent = new LicenseInfoRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        public override JsonResult Update(
            [Bind(Include = "ProductID,Code,RowVersion")]
            LicenseInfo contentObject)
        {
            var licenseInfo = ((DatabaseContext)DBContext).LicenseInfoes.Where(l => l.ProductID == contentObject.ProductID).SingleOrDefault();

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