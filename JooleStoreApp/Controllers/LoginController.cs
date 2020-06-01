﻿using JooleStore_Service;
using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JooleStoreApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View("Login", new Consumer());
        }
        public ActionResult Login()
        {
            Consumer consumer = new Consumer
            {
                UserEmail = Request.Form["LoginID"],
                UserPassword = Request.Form["LoginPW"]
            };

            Service service = new Service();
            bool login = false;
            login = service.LoginCustomer(consumer.UserEmail, consumer.UserPassword);

            if (login)
            {
                FormsAuthentication.SetAuthCookie(consumer.UserEmail, true);
                return RedirectToAction("Index", "Search");
            }
            return View("Login", new Consumer());
        }

        [HttpPost]
        public ActionResult SignUp(HttpPostedFileBase signupImage)
        {
            string username = Request.Form["signup-username"];
            string email = Request.Form["signup-email"];
            string password = Request.Form["signup-password"];
            string confirm = Request.Form["signup-confirm"];
            string filename = username + "-profile" + Path.GetExtension(signupImage.FileName);

            if(password != confirm)
            {
                ViewBag.ErrorMsg = "Password and confirm password mismatch!";
                return View("Login", new Consumer());
            }

            Service service = new Service();
            bool registered = service.SignUpCustomer(username, password, email, filename);

            // If successfully register user to database
            if(registered)
            {
                // Save the image file to images folder
                signupImage.SaveAs(Server.MapPath("~/Images/") + filename);
                return View("Login", new Consumer());
            }
            // If user already exist in db or error during connecting to db
            else {
                return View("Login", new Consumer());
            }
        }
    }
}