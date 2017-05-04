using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourSeasonsWebShop.Models; 

namespace FourSeasonsWebShop.Controllers
{
    public class ProductController : Controller
    {
        private FourSeasonsEntities fe = new FourSeasonsEntities();
        public ActionResult Index()
        {
            ViewBag.listProducts = fe.Items.ToList();
            return View();
        }
    }
}