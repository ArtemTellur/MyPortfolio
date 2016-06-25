using _SSTU_MyPortfolio.Interfaces;
using _SSTU_MyPortfolio.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public static class LogicProvider
    {
        public static IMyPortfolioLogicUser userLogic = new UserLogic();
        public static IMyPortfolioLogicPhoto photoLogic = new PhotoLogic();
        public static IMyPortfolioLogicAlbum albumLogic = new AlbumLogic();
        public static IMyPortfolioLogicComment commentLogic = new CommentLogic();
        public static IMyPortfolioLogicLike likeLogic = new LikeLogic();
    }
}