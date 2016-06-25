using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class LikeController : Controller
    {
        [Authorize]
        public ActionResult GetLikes(int photoId)
        {
            var likes = LogicProvider.likeLogic.GetLikesOfPhoto(photoId).Select(a => new LikeVM(a));
            return Json(likes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Toggle(int photoId)
        {
            var likes = LogicProvider.likeLogic.GetLikesOfPhoto(photoId).Select(a => new LikeVM(a));
            var userId = LogicProvider.userLogic.GetByEmail(User.Identity.Name).UserId;
            var existingLike = likes.Where(a => a.UserId == userId && a.PhotoId == photoId);
            if (existingLike.Any())
            {
                LogicProvider.likeLogic.Delete(existingLike.First().LikeId);
                return Json(false, JsonRequestBehavior.DenyGet);
            }
            LogicProvider.likeLogic.Add(new Like(photoId, userId));
            return Json(true, JsonRequestBehavior.DenyGet);
        }
    }
}