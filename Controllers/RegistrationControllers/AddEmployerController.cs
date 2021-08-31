using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseAccessLayer;
using CareerSolutionsPortal.Models.RegisterModels;
using BusinessAccessLayer.Register;

namespace CareerSolutionsPortal.Controllers.RegistrationControllers
{
    public class AddEmployerController : Controller
    {
        
        DALEmployerCredentials dal = new DALEmployerCredentials();


        // GET: AddEmployer/Details/5
        public ActionResult Details(int id)
        {
            BALEmployerRegister data = dal.FindEmployeeDetails(id);
            EmployerRegisterModel e = new EmployerRegisterModel();
            e.EmpId = Convert.ToInt32(data.EmpId);
            e.FullName = data.FullName;
            e.Email = data.Email;
            e.Phone = data.Phone;
            e.CompanyName = data.CompanyName;
            return View(e);
        }

        // GET: AddEmployer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddEmployer/Create
        [HttpPost]
        public ActionResult Create(EmployerRegisterModel emp)
        {
            try
            {
                BALEmployerRegister e = new BALEmployerRegister();
                e.FullName = emp.FullName;
                e.Email = emp.Email;
                e.Password = emp.Password;
                e.Phone = emp.Phone;
                e.CompanyName = emp.CompanyName;
                dal.AddEmployer(e);

                return RedirectToAction("Login","EmployerLogin");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddEmployer/Edit/5
        public ActionResult Edit(int id)
        {
            BALEmployerRegister data = dal.FindEmployeeDetails(id);
            EmployerRegisterModel c = new EmployerRegisterModel();
            c.EmpId = data.EmpId;
            c.FullName = data.FullName;
            c.Email = data.Email;
            c.Phone = data.Phone;
            c.CompanyName = data.CompanyName;
            return View(c);
        }

        // POST: AddEmployer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployerRegisterModel collection)
        {
            try
            {
                BALEmployerRegister c = new BALEmployerRegister();
                c.EmpId = id;
                c.FullName = collection.FullName;
                c.Email = collection.Email;
                c.Phone = collection.Phone;
                c.CompanyName = collection.CompanyName;
                dal.UpdateEmployer(c);

                return RedirectToAction("Index","EmployerHome");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddEmployer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddEmployer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
