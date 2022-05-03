
using Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proxy.Sengleton
{
    public sealed class SengltonOrder
    {

        private static SengltonOrder sengltonOrder = null;

        

        public SengltonOrder GetSengltonOrder()
        {
            if (sengltonOrder == null)
            {
                sengltonOrder = new SengltonOrder();
                return sengltonOrder;
            }
            else
            {
                return sengltonOrder;
            }
        }

        public int Getime(List<order> orders)
        {
            int time = 0;
            foreach(order item in orders)
            {
                time = time + item.itemfood.time;
            }

            return time;
        }

        public int GetPrice(List<order> orders)
        {
            int price = 0;
            foreach (order  item in orders)
            {
                price = item.itemfood.price + price;
            }
            return price;
        }

        public int GetDiscount(List<order> orders)
        {
             int price = GetPrice(orders);
             if(price > 300)
             {
               price = Convert.ToInt32(price * 0.85);
             }
             return price;
        }

    }
}