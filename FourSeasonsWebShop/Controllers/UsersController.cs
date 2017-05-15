using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FourSeasonsWebShop.Models; 

namespace FourSeasonsWebShop.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            using (FourSeasonsEntities fe = new FourSeasonsEntities())
            { 
                return View(fe.Users.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using(FourSeasonsEntities fe = new FourSeasonsEntities())
                {
                    fe.Users.Add(user);
                    fe.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " succesfully registered.";
            }

            return View(); 

        }

        //Login

        public ActionResult LogIn()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult LogIn(User user)
        {
            using(FourSeasonsEntities fe = new FourSeasonsEntities())
            {
                var usr = fe.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if(usr != null)
                {
                    Session["ID"] = usr.Id.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn"); 

                }

                else
                {
                    ModelState.AddModelError("", "Username og Password is wrong");
                }
            }
            return View(); 
        }

        public ActionResult LoggedIn()
        {
            if(Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login"); 
            }
        }
    }
}