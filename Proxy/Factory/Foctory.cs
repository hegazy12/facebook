using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxy.Factory;
using Proxy.Admin;
using Proxy.Sengleton;
using Proxy.Models;
using Proxy.facade;

namespace Proxy.Factory
{
   
    public class FoctoryAdmin
    {
        public ProxyAdmin GetProxyAdmin()
        {
            return new ProxyAdmin();
        }
    }
    public class FoctoryOrder
    {
        public SengltonOrder GetSengltonOrder()
        {
            return new SengltonOrder().GetSengltonOrder();
        }

        public order GetOrder()
        {
            return new order();
        }
    }
    public class Foctorymeal
    {
        public meal Getmeal()
        {
            return new meal();
        }
    }
}