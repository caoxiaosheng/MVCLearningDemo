using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessEntities;
using BusinessLayer;

namespace MVCLearningDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(UserDetails userDetails)
        {
            EmployeeBusinessLayer employeeBusinessLayer=new EmployeeBusinessLayer();
            if (employeeBusinessLayer.IsValidUser(userDetails))
            {
                FormsAuthentication.SetAuthCookie(userDetails.UserName, false);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError","用户名或密码错误^o^");
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}