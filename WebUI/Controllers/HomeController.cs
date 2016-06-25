using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.ViewModels;
using WebUI.ViewModels.UserViews;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var email = User.Identity.Name;
            var user = new UserAuthVM(email);
            return View(user);
        }
    }
}