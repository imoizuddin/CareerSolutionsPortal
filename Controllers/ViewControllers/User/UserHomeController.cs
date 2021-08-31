using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerSolutionsPortal.Controllers.ViewControllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }
    }
}