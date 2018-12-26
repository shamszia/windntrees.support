using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Controllers;
using Abstraction.Controllers;

namespace Application.Areas.MyAccount.Controllers
{
    public class HelpController : BasicController
    {
        // GET: MyAccount/Help
        public ActionResult Index()
        {
            return Redirect("~/help/index");
        }

        public ActionResult About()
        {
            return Redirect("~/help/about");
        }
    }
}