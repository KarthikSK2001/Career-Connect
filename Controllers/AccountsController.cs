using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CareerConnect.Models;

namespace CareerConnect.Controllers
{
    public class AccountsController : Controller
    {
        db_careerhuntEntities DBObj = new db_careerhuntEntities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = DBObj.tbl_users.Any(x => x.Email == credentials.Email && x.Password == credentials.Password);
            tbl_users userinfo = DBObj.tbl_users.FirstOrDefault(x => x.Email == credentials.Email && x.Password == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("","Invalid User Credentials!");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(tbl_users userinfo)
        {
            DBObj.tbl_users.Add(userinfo);
            DBObj.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}