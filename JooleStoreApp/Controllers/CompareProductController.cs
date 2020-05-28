using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleStoreApp.Controllers
{
    public class CompareProductController : Controller
    {
        // GET: CompareProduct
        public ActionResult Index()
        {
            return View("CompareProduct");
        }
    }
}