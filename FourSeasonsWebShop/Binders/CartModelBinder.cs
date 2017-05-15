//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using FourSeasonsWebShop.Models;

//namespace FourSeasonsWebShop.Binders
//{
//    public class CartModelBinder : IModelBinder //Bruger en MVC model binder!
//    {
//        private const string sessionKey = "Cart"; //konstant 
//        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        {
//            //Tjekker sessions for sessionkey
//            Cart cart = null;
//            if (controllerContext.HttpContext.Session != null)
//            {
//                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
//            }
//            if(cart == null)
//            {
//                cart = new Cart();
//                if(controllerContext.HttpContext.Session != null)
//                {
//                    controllerContext.HttpContext.Session[sessionKey] = cart; 
//                }

                
//            }
//            return cart;
//        }

        
//    }
//}