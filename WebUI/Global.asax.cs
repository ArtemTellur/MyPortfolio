using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Models;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var email = ConfigurationManager.AppSettings["AdminEmailDefault"];
            if (!LogicProvider.userLogic.UserExsist(email))
            {
                var password = ConfigurationManager.AppSettings["AdminPasswordDefault"];
                LogicProvider.userLogic.Add(new User("Вика", DateTime.Parse("1997/08/28"), ":)", email, password, 1, 25));
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
