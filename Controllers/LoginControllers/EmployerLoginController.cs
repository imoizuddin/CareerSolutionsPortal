using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerSolutionsPortal.Models;

namespace CareerSolutionsPortal.Controllers
{
    public class EmployerLoginController : Controller
    {
        // GET: UserLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployerLoginModel model)
        {
            if (model.Email == "abc@gmail.com" && model.Password == "pass")
            {
                Session["UserID"] = Guid.NewGuid();
                return RedirectToAction("Index", "EmployerHome");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
    }
}