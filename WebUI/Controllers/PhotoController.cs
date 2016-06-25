using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.PhotoViews;
using WebUI.ViewModels.UserViews;

namespace WebUI.Controllers
{
    public class PhotoController : Controller
    {
        [Authorize]
        public FileResult GetPhoto(int pictureId)
        {
            var picture = LogicProvider.photoLogic.GetById(pictureId);
            return File(picture.Image, picture.Mime);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, int userId)
        {
            var userEmail = LogicProvider.userLogic.GetAll().Select(a => new UserVM(a)).Where(a => a.Id == userId).First().Email;
            if (User.Identity.Name == userEmail)
            {
                LogicProvider.photoLogic.Delete(id);
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            return Json(false, JsonRequestBehavior.DenyGet);
        }
    }
}