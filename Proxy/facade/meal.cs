using Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proxy.facade
{
    public class meal
    {
        private Cmodel db = new Cmodel();
        public void AddBreakfast(int user)
        {
            order order = new order();
            order.itemfood = db.itemfoods.Find(3);
            order.User = user;
            order.item_id = 3;
            
            db.order.Add(order);
            db.SaveChanges();
            
            db.order.Add(order);
            db.SaveChanges();
            
            db.order.Add(order);
            db.SaveChanges();


        }

        public void AddDinner(int user)
        {
            order order = new order();
            order.itemfood = db.itemfoods.Find(9);
            order.User = user;
            order.item_id = 9;

            db.order.Add(order);
            db.SaveChanges();

            db.order.Add(order);
            db.SaveChanges();

            db.order.Add(order);
            db.SaveChanges();

            order.itemfood = db.itemfoods.Find(23);
            order.User = user;
            order.item_id = 23;

            db.order.Add(order);
            db.SaveChanges();

            order.itemfood = db.itemfoods.Find(26);
            order.User = user;
            order.item_id = 26;

            db.order.Add(order);
            db.SaveChanges();
        }

        public void AddLunch(int user)
        {
            order order = new order();
            order.itemfood = db.itemfoods.Find(14);
            order.User = user;
            order.item_id = 14;

            db.order.Add(order);
            db.SaveChanges();

            db.order.Add(order);
            db.SaveChanges();

            db.order.Add(order);
            db.SaveChanges();

            order.itemfood = db.itemfoods.Find(26);
            order.User = user;
            order.item_id = 26;

            db.order.Add(order);
            db.SaveChanges();

            db.order.Add(order);
            db.SaveChanges();
        }

    }
}