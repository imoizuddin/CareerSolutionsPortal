using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessAccessLayer;
using DatabaseAccessLayer;
using CareerSolutionsPortal.Models;

namespace CareerSolutionsPortal.Controllers
{
    public class JobController : Controller
    {
        DALJobDetails dal = new DALJobDetails();
        // GET: Job
        public ActionResult Index()
        {
            List<BALJobModel> categories = dal.GetJobs();
            List<JobModel> mlist = new List<JobModel>();
            foreach (var item in categories)
            {
                JobModel c = new JobModel();
                c.JobId = item.JobId;
                c.EmployeeId = item.EmployeeId;
                c.CompanyName = item.CompanyName;
                c.JobProfile = item.JobProfile;
                c.Description = item.Description;
                c.Location = item.Location;
                c.Salary = item.Salary;
                c.JobPostedDate = item.JobPostedDate;
                mlist.Add(c);
            }


            return View(mlist);
        }

        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Job/Delete/5
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
