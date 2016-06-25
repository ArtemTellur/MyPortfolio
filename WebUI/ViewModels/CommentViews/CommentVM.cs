using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.CommentViews
{
    public class CommentVM
    {
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int CommentId { get; set; }
        public int UserPhotoId { get; set; }

        public CommentVM(Comment comment)
        {
            UserId = comment.UserId;
            Text = comment.Text;
            CommentId = comment.CommentId;
            PhotoId = comment.PhotoId;
            Name = LogicProvider.userLogic.GetById(UserId).UserName;
            UserPhotoId = LogicProvider.userLogic.GetById(UserId).PictureId;
        }
    }
}