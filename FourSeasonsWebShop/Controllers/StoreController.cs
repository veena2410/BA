using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourSeasonsWebShop.Models;

namespace FourSeasonsWebShop.Controllers
{
    public class StoreController : Controller
    {

        FourSeasonsEntities fe = new FourSeasonsEntities();

        // GET: Store: List of categories from our store
        public ActionResult Index()
        {

            var categories = fe.Categories.ToList();

            return View(categories);
        }


        public ActionResult Browse(string category)
        {
            var categoryModel = fe.Categories.Include("Items")
            .Single(c => c.Name == category);

            return View(categoryModel);
        }

        //public ActionResult Details(int id)
        //{
        //    var Item = new Product { Title = "Item" + id };
        //    return View(Item);
        //}

    }
}