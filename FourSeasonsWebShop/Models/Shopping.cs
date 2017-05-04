﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using FourSeasonsWebShop.Models;

//namespace FourSeasonsWebShop.Models
//{
//    public class Shopping
//    {

//        FourSeasonsEntities db = new FourSeasonsEntities();
//        string ShoppingCId { get; set; } // YOU SURE ABOUT THIS?!

//        public const string CartSessionKey = "CartId";

//        public static Shopping GetCart(HttpContextBase context)
//        {
//            var cart = new Shopping();
//            cart.ShoppingCId = cart.GetCartId(context);
//            return cart;

//        }

//        // Helper method to simplify shopping cart calls
//        public static Shopping GetCart(Controller controller)
//        {
//            return GetCart(controller.HttpContext);
//        }

//        // ADD TO CART
//        public void AddToCart(Item item)
//        {
//            var cartItem = db.Carts.SingleOrDefault(
//                c => c.CartId == ShoppingCId
//                && c.ItemId == item.ItemId
//                );

//            if (cartItem == null)
//            {
//                cartItem = new Cart
//                {
//                    ItemId = item.ItemId,
//                    CartId = ShoppingCId,
//                    Count = 1,
//                    DateCreated = DateTime.Now

//                };
//                db.Carts.Add(cartItem);
//            }

//            else
//            {
//                cartItem.Count++;
//            }

//            db.SaveChanges();
//        }

//        //REMOVE FROM CART
//        public int RemoveFromCart(int id)
//        {
//            var cartItem = db.Carts.Single(
//                cart => cart.CartId == ShoppingCId
//                && cart.RecordId == id);

//            int itemCount = 0;

//            if (cartItem != null)
//            {
//                if (cartItem.Count > 1)
//                {
//                    cartItem.Count--;
//                    itemCount = cartItem.Count; //???

//                }
//                else
//                {
//                    db.Carts.Remove(cartItem);
//                }
//                db.SaveChanges();
//            }
//            return itemCount;
//        }

//        public void EmptyCart()
//        {
//            var cartItems = db.Carts.Where(
//                cart => cart.CartId == ShoppingCId);

//            foreach (var cartItem in cartItems)
//            {
//                db.Carts.Remove(cartItem);
//            }

//            db.SaveChanges();
//        }

//        public List<Cart> GetCartItems()
//        {
//            return db.Carts.Where(
//                cart => cart.CartId == ShoppingCId).ToList();
//        }

//        public int GetCount()
//        {
//            int? count = (from cartItems in db.Carts
//                          where cartItems.CartId == ShoppingCId
//                          select (int?)cartItems.Count).Sum();

//            return count ?? 0;
//        }

//        public decimal GetTotal()
//        {
//            decimal? total = (from cartItems in db.Carts
//                              where cartItems.CartId == ShoppingCId
//                              select (int?)cartItems.Count.
//                              cartItems.Item.Price).sum();

//            return total ?? decimal.Zero;
//        }

//        public int CreateOrder(Order order)
//        {
//            decimal orderTotal = 0;
//            var cartItems = GetCartItems();

//            foreach (var item in cartItems)
//            {
//                var orderDetail = new OrderDetail
//                {
//                    ItemId = item.ItemId,
//                    OrderId = order.OrderId.
//                    UnitPrice = item.Item.Price,
//                    Quantity = item.Count

//                };

//                orderTotal += (item.Count * item.Item.Price);

//                db.OrderDetails.Add(orderDetail);
//            }
//            order.Total = orderTotal;

//            db.SaveChanges();

//            EmptyCart();

//            return order.OrderId;
//        }

//        public string GetCartId(HttpContextBase context)
//        {
//            if (context.Session[CartSessionKey] == null)
//            {
//                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
//                {
//                    context.Session[CartSessionKey] =
//                        context.User.Identity.Name;
//                }
//                else
//                {
//                    Guid tempCartId = Guid.NewGuid();

//                    context.Session[CartSessionKey] = tempCartId.ToString();

//                }
//            }
//            return context.Session[CartSessionKey].ToString();
//        }

//        public void MigrateCart(string userName)
//        {
//            var shoppingCart = db.Carts.Where(
//                c => c.CartId == ShoppingCId);

//            foreach (Cart item in shoppingCart)
//            {
//                item.CartId = userName;
//            }
//            db.SaveChanges();
//        }
//    }
//}