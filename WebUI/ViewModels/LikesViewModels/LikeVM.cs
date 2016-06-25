using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class LikeVM
    {
        public LikeVM() { }

        public int LikeId { get; set; }
        public int PhotoId { get; set; }
        public int UserId { get; set; }

        public LikeVM(Like like)
        {
            LikeId = like.LikeId;
            PhotoId = like.PhotoId;
            UserId = like.UserId;
        }
    }
}