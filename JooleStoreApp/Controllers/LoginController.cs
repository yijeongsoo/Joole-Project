using JooleStore_Service;
using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
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
            return View("Login");
        }
        public ActionResult Login()
        {
            System.Diagnostics.Debug.WriteLine("Login function called");

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
            return View();
        }

    }
}