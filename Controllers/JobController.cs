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
            BALJobModel data = dal.FindJobDetails(id);
            JobModel c = new JobModel();
            c.JobId = Convert.ToInt32(data.JobId);
            c.EmployeeId = data.EmployeeId;
            c.CompanyName = data.CompanyName;
            c.JobProfile = data.JobProfile;
            c.Description = data.Description;
            c.Location = data.Location;
            c.Salary = data.Salary;
            c.JobPostedDate = data.JobPostedDate;
            return View(c);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(JobModel job)
        {
            try
            {
                BALJobModel c = new BALJobModel();
                c.EmployeeId = job.EmployeeId;
                c.CompanyName = job.CompanyName;
                c.JobProfile = job.JobProfile;
                c.Description = job.Description;
                c.Location = job.Location;
                c.Salary = job.Salary;
                c.JobPostedDate = job.JobPostedDate;
                dal.AddJob(c);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            BALJobModel data = dal.FindJobDetails(id);
            JobModel c = new JobModel();
            c.EmployeeId = data.EmployeeId;
            c.CompanyName = data.CompanyName;
            c.JobProfile = data.JobProfile;
            c.Description = data.Description;
            c.Location = data.Location;
            c.Salary = data.Salary;
            c.JobPostedDate = data.JobPostedDate;
            return View(c);
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, JobModel collection)
        {
            try
            {
                BALJobModel c = new BALJobModel();
                c.JobId = id;
                c.EmployeeId = collection.EmployeeId;
                c.CompanyName = collection.CompanyName;
                c.JobProfile = collection.JobProfile;
                c.Description = collection.Description;
                c.Location = collection.Location;
                c.Salary = collection.Salary;
                c.JobPostedDate = collection.JobPostedDate;
                dal.UpdateJob(c);

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
            BALJobModel data = dal.FindJobDetails(id);
            JobModel c = new JobModel();
            c.JobId = id;
            c.EmployeeId = data.EmployeeId;
            c.CompanyName = data.CompanyName;
            c.JobProfile = data.JobProfile;
            c.Description = data.Description;
            c.Location = data.Location;
            c.Salary = data.Salary;
            c.JobPostedDate = data.JobPostedDate;
            return View(c);
        }

        // POST: Job/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dal.DeleteJob(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
