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

        [HttpPost]
        public ActionResult Login(Consumer consumer)
        {
            Service service = new Service();
            bool login = service.LoginCustomer(consumer.UserEmail, consumer.UserPassword);

            if (login)
            {
                FormsAuthentication.SetAuthCookie(consumer.UserEmail, true);
                return RedirectToAction("ProductSearch", "ProductSearch");
            }
            return View();
        }
    }
}