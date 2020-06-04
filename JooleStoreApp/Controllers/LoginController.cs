using JooleStore_Service;
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

        public void setSession(string email)
        {
            Service service = new Service();
            
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
                Session["ProfileImage"] = service.GetUser(consumer.UserEmail)["UserImage"];
                Session["isLoggedIn"] = true;
                return RedirectToAction("Index", "Search");
            }
            ViewBag.ErrorMsg = "Wrong Username and Password!";
            return View("Login", new Consumer());
        }

        [HttpPost]
        public ActionResult SignUp(HttpPostedFileBase signupImage)
        {
            string username = Request.Form["UserName"];
            string email = Request.Form["UserEmail"];
            string password = Request.Form["UserPassword"];
            string confirm = Request.Form["ConfirmPassword"];
            string filename = "";

            if (signupImage != null)
            {
                filename = username + "-profile" + Path.GetExtension(signupImage.FileName);
            }

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
                if(signupImage != null)
                {
                    signupImage.SaveAs(Server.MapPath("~/Images/") + filename);
                }

                Session["ProfileImage"] = filename;
                Session["isLoggedIn"] = true;
                return RedirectToAction("Index", "Search");
            }

            // If user already exist in db or error during connecting to db
            else {
                ViewBag.ErrorMsg = "User already exist!";
                return View("Login", new Consumer());
            }
        }
    }
}