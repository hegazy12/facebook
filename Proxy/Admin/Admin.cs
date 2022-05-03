using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxy.Models;

namespace Proxy.Admin
{
    public interface Admin
    {
        int AddItem(itemfood itemFood);

    }

    public class ProxyAdmin : Admin
    {
        private _Admin _Admin = new _Admin();
        public string key = "non";
        public string log_Admin(string username , string password)
        {
            if (username == "admin" && password =="1234")
            {
                return "admin";
            }
            else
            {
                return "non";
            }
        }


        public bool IsLog(string rol)
        { 
            if (rol == "admin")
            {
               return true;
            }
            else
            {
               return false;
            }
        }
        
        public int AddItem(itemfood itemFood)
        {
            if (IsLog(this.key))
            {
                return _Admin.AddItem(itemFood);
            }
            else
            {
                return -1;
            }
        }
    }




    class _Admin : Admin
    {
        private Cmodel db = new Cmodel();

       
        public int AddItem(itemfood itemFood)
        {
            try
            {
                
                db.itemfoods.Add(itemFood);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

       
    }
}