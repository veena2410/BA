using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourSeasonsWebShop.Models;

namespace FourSeasonsWebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private FourSeasonsEntities fe = new FourSeasonsEntities();
       
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                Session["cart"] = cart;
            }
            
                //List<Product> cart = (List<Product>)Session["cart"];
                //Session["cart"] = cart;
            
            return View("Cart");
            
        }

        private int isExisting(int id)
        {
            List<Product> cart = (List<Product>)Session["cart"];
            for (int i=0; i<cart.Count; i++)
                if (cart[i].It.ItemId == id)
                    return i;
            return -1;
            
        }



        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Product> cart = (List<Product>)Session["cart"];

            if(cart[index].Quantity > 1)
            {
                cart[index].Quantity--; 
            }

            else
            {
                cart.RemoveAt(index);
            }

            Session["cart"] = cart;
            return View("Cart");
        }
        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(new Product(fe.Items.Find(id), 1));
                Session["cart"] = cart; 
            }
            else
            {
                List<Product> cart = (List<Product>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Product(fe.Items.Find(id), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetail());
        }

    }
}