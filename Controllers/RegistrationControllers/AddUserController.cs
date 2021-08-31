using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerSolutionsPortal.Models.RegisterModels;

namespace CareerSolutionsPortal.Controllers.RegisterationControllers
{
    public class AddUserController : Controller
    {
        // GET: AddUser
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel model)
        {
            return View();
        }
    }
}