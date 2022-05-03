using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proxy.Models
{
    public class Cmodel:DbContext
    {
        
        public DbSet<itemfood> itemfoods {get; set;}
        public DbSet<order> order { get; set;}
    }


    public class itemfood
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string Description { get; set; }
        public int type { get; set; }
        public int price { get; set; }
        public int time { get; set; }
    }


    
    public class order
    {
        public int id { get; set; }
        public int User {get; set;}
        public int item_id {get; set;}
        public itemfood itemfood { get; set; }
    }
}