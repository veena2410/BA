using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FourSeasonsWebShop.Models;

namespace FourSeasonsWebShop.Controllers
{
    public class Product
    {
        private Item it = new Item();

        public Item It
        {
            get { return it; }
            set { it = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //public Product()
        //{

        //}

        public Product(Item item, int quantity)
        {
            this.It = item;
            this.quantity = quantity; 
        }

       
    }
}