using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerSolutionsPortal.Models.RegisterModels;
using DatabaseAccessLayer;
using BusinessAccessLayer.Register;

namespace CareerSolutionsPortal.Controllers.RegisterationControllers
{
    public class AddUserController : Controller
    {
     
         DALUserCredentials dal = new DALUserCredentials();


        // GET: AddEmployer/Details/5
        public ActionResult Details(int id)
        {
            BALUserRegister data = dal.FindUserDetails(id);
            UserRegisterModel e = new UserRegisterModel();
            e.UserId = Convert.ToInt32(data.UserId);
            e.FullName = data.FullName;
            e.Email = data.Email;
            e.Phone = data.Phone;
            return View(e);
        }

        // GET: AddEmployer/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: AddEmployer/Create
        [HttpPost]
        public ActionResult Register(UserRegisterModel emp)
        {
            try
            {
                BALUserRegister e = new BALUserRegister();
                e.FullName = emp.FullName;
                e.Email = emp.Email;
                e.Password = emp.Password;
                e.Phone = emp.Phone;
                dal.AddUser(e);

                return RedirectToAction("Login", "UserLogin");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddEmployer/Edit/5
        public ActionResult Edit(int id)
        {
            BALUserRegister data = dal.FindUserDetails(id);
            UserRegisterModel c = new UserRegisterModel();
            c.UserId = data.UserId;
            c.FullName = data.FullName;
            c.Email = data.Email;
            c.Phone = data.Phone;
            return View(c);
        }

        // POST: AddEmployer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserRegisterModel collection)
        {
            try
            {
                BALUserRegister c = new BALUserRegister();
                c.UserId = id;
                c.FullName = collection.FullName;
                c.Email = collection.Email;
                c.Phone = collection.Phone;
                dal.UpdateUser(c);

                return RedirectToAction("Index", "UserHome");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddEmployer/Delete/5
        public ActionResult Delete(int id)
        {
            BALUserRegister data = dal.FindUserDetails(id);
            UserRegisterModel c = new UserRegisterModel();
            c.UserId = data.UserId;
            c.FullName = data.FullName;
            c.Email = data.Email;
            c.Phone = data.Phone;
            return View(c);
        }

        // POST: AddEmployer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dal.DeleteUser(id);
                return RedirectToAction("Index","UserHome");
            }
            catch
            {
                return View();
            }
        }
    }
}