using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerSolutionsPortal.Filters;

namespace CareerSolutionsPortal.Controllers.ViewControllers
{
    [UserAuthenticationFilter]
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult Index()
        {
            //EditProfile
            //AppliedJobs
            //DisplayJobs
            return View();
        }

        public ActionResult EditUserDetails()
        {
            return View();
        }

        public ActionResult AppliedJobs()
        {
            return View();
        }

        public ActionResult DisplayJobs()
        {
            return View();
        }
    }
}