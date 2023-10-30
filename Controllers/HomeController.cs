using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareerConnect.Models;

namespace CareerConnect.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        db_careerhuntEntities DBObj = new db_careerhuntEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "JobSeeker, Employer, Guest")]
        public ActionResult Contact()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "JobSeeker, Employer, Guest")]
        public ActionResult AddContact(tbl_contact model)
        {
            if (ModelState.IsValid)
            {
                tbl_contact tb_obj = new tbl_contact();
                tb_obj.id = model.id;
                tb_obj.Name = model.Name;
                tb_obj.Email = model.Email;
                tb_obj.Mobile = model.Mobile;
                tb_obj.Message = model.Message;

                DBObj.tbl_contact.Add(tb_obj);
                DBObj.SaveChanges();
            }

            ModelState.Clear();
            return View("Contact");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetContactsList()
        {
            var result = DBObj.tbl_contact.ToList();
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteContact(int id)
        {
            var result = DBObj.tbl_contact.Where(x => x.id == id).First();
            DBObj.tbl_contact.Remove(result);
            DBObj.SaveChanges();

            var list = DBObj.tbl_contact.ToList();
            
            return View("GetContactsList", list);
        }

        // Job Seekers Code
        [Authorize(Roles = "JobSeeker")]
        public ActionResult JobProfile(tbl_jobseekers_profile obj)
        {
            if (obj!=null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
           
        }
        [HttpPost]
        [Authorize(Roles = "JobSeeker")]
        public ActionResult AddJobProfile(tbl_jobseekers_profile model, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                tbl_jobseekers_profile tblObj = new tbl_jobseekers_profile();
                tblObj.id = model.id;
                tblObj.Name = model.Name;
                tblObj.Profession = model.Profession;
                tblObj.Bio = model.Bio;
                tblObj.Location = model.Location;
                tblObj.Mobile = model.Mobile;
                tblObj.Email = model.Email;
                tblObj.Education = model.Education;
                tblObj.Skills = model.Skills;
                tblObj.SocialMedia = model.SocialMedia;
                tblObj.Image = model.Image;
                tblObj.IsProfileCreated = true;
                if (image1 != null && image1.ContentLength > 0)
                {
                    tblObj.Image = new byte[image1.ContentLength];
                    image1.InputStream.Read(tblObj.Image, 0, image1.ContentLength);
                }
                if (model.id == 0)
                {
                    DBObj.tbl_jobseekers_profile.Add(tblObj);
                    DBObj.SaveChanges();
                }
                else
                {
                    DBObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                    DBObj.SaveChanges();
                }

                
                return RedirectToAction("JobProfile", "Home");
            }

            ModelState.Clear();
            return View("JobProfile");
        }
        [Authorize(Roles = "JobSeeker, Employer, Admin")]
        public ActionResult GetJobSeekerProfileData()
        {
            var result = DBObj.tbl_jobseekers_profile.ToList();
            return View(result);
        }
        [Authorize(Roles = "Employer")]
        public ActionResult EmployerProfile(tbl_employer_profile obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public ActionResult AddEmployerProfile(tbl_employer_profile model, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                tbl_employer_profile tblObj = new tbl_employer_profile();
                tblObj.id = model.id;
                tblObj.CName = model.CName;
                tblObj.CBio = model.CBio;
                tblObj.CLocation = model.CLocation;
                tblObj.CEmail = model.CEmail;
                tblObj.CIndustry = model.CIndustry;
                tblObj.CSocialMedia = model.CSocialMedia;

                if (image1 != null && image1.ContentLength > 0)
                {
                    tblObj.CImage = new byte[image1.ContentLength];
                    image1.InputStream.Read(tblObj.CImage, 0, image1.ContentLength);
                }

                if(model.id == 0)
                {
                    DBObj.tbl_employer_profile.Add(tblObj);
                    DBObj.SaveChanges();
                }
                else
                {
                    DBObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                    DBObj.SaveChanges();
                }
                ModelState.Clear();
            }

            return View("EmployerProfile");
        }
        [Authorize(Roles = "Employer, Admin")]
        public ActionResult GetEmployerProfileData()
        {
            var result = DBObj.tbl_employer_profile.ToList();
            return View(result);
        }
        [Authorize(Roles = "Employer")]
        public ActionResult JobPosts(tbl_job_posts obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
            
        }
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public ActionResult AddJobPosts(tbl_job_posts model, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                tbl_job_posts tblObj = new tbl_job_posts();
                tblObj.id = model.id;
                tblObj.CMName = model.CMName;
                tblObj.CMRole = model.CMRole;
                tblObj.CMLocation = model.CMLocation;
                tblObj.CMMode = model.CMMode;
                tblObj.CMPay = model.CMPay;
                tblObj.CMLink = model.CMLink;

                if (image1 != null && image1.ContentLength > 0)
                {
                    tblObj.CMImage = new byte[image1.ContentLength];
                    image1.InputStream.Read(tblObj.CMImage, 0, image1.ContentLength);
                }

                if (model.id == 0)
                {
                    DBObj.tbl_job_posts.Add(tblObj);
                    DBObj.SaveChanges();
                }
                else
                {
                    DBObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                    DBObj.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("JobPosts");
        }
        [Authorize(Roles = "JobSeeker, Employer, Guest, Admin")]
        public ActionResult GetJobPostsData()
        {
            var result = DBObj.tbl_job_posts.ToList();
            return View(result);
        }
        [Authorize(Roles = "Employer")]
        public ActionResult DeleteJob(int id)
        {
            var result = DBObj.tbl_job_posts.Where(x => x.id == id).First();
            DBObj.tbl_job_posts.Remove(result);

            DBObj.SaveChanges();

            var list = DBObj.tbl_job_posts.ToList();
            return View("GetJobPostsData", list);
        }
        [Authorize(Roles = "College")]
        public ActionResult CollegeProfile(tbl_colleges_profile obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        [Authorize(Roles = "College")]
        public ActionResult AddCollegeProfile(tbl_colleges_profile model, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                tbl_colleges_profile tblObj = new tbl_colleges_profile();
                tblObj.ColName = model.ColName;
                tblObj.ColEmail = model.ColEmail;
                tblObj.ColAbout = model.ColAbout;
                tblObj.ColLocation = model.ColLocation;
                tblObj.ColURL = model.ColURL;

                if (image1 != null && image1.ContentLength > 0)
                {
                    tblObj.ColImage = new byte[image1.ContentLength];
                    image1.InputStream.Read(tblObj.ColImage, 0, image1.ContentLength);
                }

                if (model.id == 0)
                {
                    DBObj.tbl_colleges_profile.Add(tblObj);
                    DBObj.SaveChanges();
                }
                else
                {
                    DBObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                    DBObj.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("CollegeProfile");
        }
        [Authorize(Roles = "College, Admin")]
        public ActionResult GetCollegeProfileData()
        {
            var result = DBObj.tbl_colleges_profile.ToList();
            return View(result);
        }
        [Authorize(Roles = "College")]
        public ActionResult CollegeEvents(tbl_college_events obj)
        {
            if (obj!=null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "College")]
        public ActionResult AddCollegeEvents(tbl_college_events model)
        {
            if (ModelState.IsValid)
            {
                tbl_college_events tblObj = new tbl_college_events();
                tblObj.id = model.id;
                tblObj.IName = model.IName;
                tblObj.IWinner = model.IWinner;
                tblObj.IAbout = model.IAbout;
                tblObj.ITech = model.ITech;
                tblObj.ILink = model.ILink;


                if (model.id == 0)
                {
                    DBObj.tbl_college_events.Add(tblObj);
                    DBObj.SaveChanges();
                }
                else
                {
                    DBObj.Entry(tblObj).State = System.Data.Entity.EntityState.Modified;
                    DBObj.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("CollegeEvents");
        }
        [Authorize(Roles = "JobSeeker, College, Guest, Admin")]
        public ActionResult GetCollegeEventsData()
        {
            var result = DBObj.tbl_college_events.ToList();
            return View(result);
        }
        [Authorize(Roles = "College")]
        public ActionResult DeleteEvent(int id)
        {
            var result = DBObj.tbl_college_events.Where(x => x.id == id).First();
            DBObj.tbl_college_events.Remove(result);

            DBObj.SaveChanges();

            var list = DBObj.tbl_college_events.ToList();
            return View("GetCollegeEventsData", list);
        }
    }
}