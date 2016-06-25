using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserAuthVM
    {
        public UserAuthVM() { }

        public UserAuthVM(string email)
        {
            User = LogicProvider.userLogic.GetByEmail(email);
        }

        public User User { get; set; }

        public int GetPhotoId(string email)
        {
            var PhotoId = LogicProvider.userLogic.GetByEmail(email).PictureId;
            return PhotoId;
        }

    }
}