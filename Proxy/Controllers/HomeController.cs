using Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Sengleton;
using Proxy.facade;
using Proxy.Factory;

namespace Proxy.Controllers
{
    public class HomeController : Controller
    {
        private Cmodel db = new Cmodel();
        private SengltonOrder SengltonOrder = new FoctoryOrder().GetSengltonOrder();
        private meal meal = new Foctorymeal().Getmeal();
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                Session["id"] = (db.order.ToList().Last().User + 1).ToString(); 
            }
            
            return View(db.itemfoods.ToList());
        }

        public ActionResult meals()
        {
             return View();
        }

        public ActionResult myorder()
        {
            int idx = Convert.ToInt32(Session["id"]);
            List<order> orders = db.order.Where(m => m.User == idx).ToList();
            foreach(var or in orders)
            {
                or.itemfood = db.itemfoods.Find(or.item_id);
            }

            ViewBag.price = SengltonOrder.GetDiscount(orders);
            ViewBag.time  =  SengltonOrder.Getime(orders);

            return View(orders);
        }


        public ActionResult addmeal(int? id)
        {
            int idi = Convert.ToInt32(id);
            
            if (Session["id"] == null)
            {
                Session["id"] = (db.order.ToList().Last().User + 1).ToString();
            }

            int idx = Convert.ToInt32(Session["id"]);

            if (idi == 1)
            {
                meal.AddBreakfast(idx);
            }
            else if (idi == 2)
            {
                meal.AddLunch(idx);
            }
            else if (idi == 3)
            {
                meal.AddDinner(idx);
            }
            return RedirectToAction("meals");
        }


        public ActionResult Add(int? id)
        {
            int idx = Convert.ToInt32(Session["id"]);

            itemfood itemfood = new itemfood();
            int idi = Convert.ToInt32(id);
            itemfood = db.itemfoods.Find(id);

            order order = new order();
            order.itemfood = itemfood;
            order.User = idx;
            order.item_id = itemfood.id;
            db.order.Add(order);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult cancel(int? id)
        {
            int idi = Convert.ToInt32(id);
            db.order.Remove(db.order.Find(idi));
            db.SaveChanges();
            return RedirectToAction("myorder");
        }

    }
}