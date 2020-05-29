using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleStoreApp.Models;

namespace JooleStoreApp.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index()
        {
            return View("ProductDetail");
        }
    }
}