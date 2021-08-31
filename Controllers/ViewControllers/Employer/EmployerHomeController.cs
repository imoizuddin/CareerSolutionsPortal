using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessAccessLayer;
using DatabaseAccessLayer;
using CareerSolutionsPortal.Models;
using CareerSolutionsPortal.Models.RegisterModels;
using BusinessAccessLayer.Register;
using CareerSolutionsPortal.Filters;

namespace CareerSolutionsPortal.Controllers.ViewControllers.Employer
{
    [UserAuthenticationFilter]
    public class EmployerHomeController : Controller
    {
        DALJobDetails dalJob = new DALJobDetails();
        DALEmployerCredentials dalEmp = new DALEmployerCredentials();

        // GET: EmployerHome
        public ActionResult Index()
        {
            //Edit Profile
            //CreateNewJob

            //CreatedJobs
            int id = Convert.ToInt32( Session["LoggedInUser"]);
            List<BALJobModel> categories = dalJob.GetJobs();
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

        public ActionResult CreateJob()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult CreateJob(JobModel job)
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
                dalJob.AddJob(c);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            BALEmployerRegister data = dalEmp.FindEmployeeDetails(id);
            EmployerRegisterModel e = new EmployerRegisterModel();
            e.EmpId = Convert.ToInt32(data.EmpId);
            e.FullName = data.FullName;
            e.Email = data.Email;
            e.Phone = data.Phone;
            e.CompanyName = data.CompanyName;
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            BALEmployerRegister data = dalEmp.FindEmployeeDetails(id);
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
                dalEmp.UpdateEmployer(c);

                return RedirectToAction("Index", "EmployerHome");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreatedJobs()
        {
            return View();
        }
    }
}