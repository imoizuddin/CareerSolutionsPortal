using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerSolutionsPortal.Models;
using DatabaseAccessLayer;
using BusinessAccessLayer;
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
            //if (model.Email == "abc@gmail.com" && model.Password == "pass")
            //{
            //    Session["UserID"] = Guid.NewGuid();
            //    return RedirectToAction("Index", "EmployerHome");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Invalid login attempt.");
            //    return View(model);
            //}

            DALEmployerCredentials dal = new DALEmployerCredentials();
            BALEmployerLogin bal = new BALEmployerLogin();
            bal.Email = model.Email;
            bal.Password = model.Password;
            int value = dal.CheckEmployer(bal);
            if (value != 0)
            {
                Session["LoggedInUser"] = value;
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