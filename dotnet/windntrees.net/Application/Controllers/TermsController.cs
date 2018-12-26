using Abstraction.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class TermsController : BasicController
    {
        // GET: Terms
        public ActionResult Index()
        {
            return View();
        }
    }
}