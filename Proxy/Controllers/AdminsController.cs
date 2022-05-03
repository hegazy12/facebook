using Proxy.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Models;
using System.IO;

namespace Proxy.Controllers
{
    public class AdminsController : Controller
    {
        private ProxyAdmin proxyAdmin = new Factory.FoctoryAdmin().GetProxyAdmin();
        private Cmodel db = new Cmodel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string uname = form["uname"].ToString();
            string pass = form["pass"].ToString();

            Session["key"] = proxyAdmin.log_Admin(uname, pass);
            if (proxyAdmin.IsLog(Session["key"].ToString()))
            {
                return RedirectToAction("Adminpanel");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Adminpanel()
        {
            if (proxyAdmin.IsLog(Session["key"].ToString()) == false)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult AddFoodItem()
        {
            if (proxyAdmin.IsLog(Session["key"].ToString()) == false)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public ActionResult AddFoodItem(FormCollection form, HttpPostedFileBase photo)
        {

            if (proxyAdmin.IsLog(Session["key"].ToString()) == false)
            {
                return RedirectToAction("Index");
            }

            proxyAdmin.key = Session["key"].ToString();

            itemfood itemfood = new itemfood();
            HttpPostedFileBase postedFile;
            
            try
            {
                postedFile = Request.Files["photo"];
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            }
            catch
            {
                ViewBag.sms = "your photo is null";
                return View();
            }

            itemfood.photo = "/Uploads/" + Path.GetFileName(postedFile.FileName);
            itemfood.name = form["name"].ToString();
            itemfood.price = Convert.ToInt32(form["price"]);
            itemfood.time = Convert.ToInt32(form["time"]);
            itemfood.Description = form["Description"].ToString();
            itemfood.type = Convert.ToInt32(form["type"]);
            
            proxyAdmin.AddItem(itemfood);
            
            return View();
        }

       

        public ActionResult Admin_logout()
        {
            Session["key"] = "non";
            return RedirectToAction("index","home");
        }
    }
}