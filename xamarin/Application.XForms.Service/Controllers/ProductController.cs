using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WindnTrees.Abstraction.Core.Controllers;
using WindnTrees.CRUDS.Repository.Core;
using WindnTreesSEO.Models.Database.Repositories;
using WindnTreesSEO.Models.Database;
using WindnTreesSEO.Models;
using System;

namespace WindnTreesSEO.Controllers
{
    public class ProductController : CRUDLController<Product>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override EntityRepository<Product> GetRepository()
        {
            return new ProductRepository((ApplicationContext)GetDBContext());
        }
    }
}
