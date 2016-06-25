using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.CommentViews;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        [Authorize]
        public JsonResult GetComments(int photoId)
        {
            var comments = LogicProvider.commentLogic.GetCommentsOfPhoto(photoId).Select(a => new CommentVM(a));
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult AddComment(string text, string photoId)
        {
                string email = User.Identity.Name;
                int userId = LogicProvider.userLogic.GetByEmail(email).UserId;
                int commentId = LogicProvider.commentLogic.Add(new Comment(text, int.Parse(photoId), userId));
                var newComment = new CommentVM(LogicProvider.commentLogic.GetById(commentId));
                return Json(newComment, JsonRequestBehavior.DenyGet);
        }
    }
}