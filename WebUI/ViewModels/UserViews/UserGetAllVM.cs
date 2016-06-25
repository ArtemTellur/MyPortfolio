using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserGetAllVM
    {
        public int Id { get; set; }
        public IEnumerable<UserGetVM> Users { get; set; }

        public UserGetAllVM(int id)
        {
            Id = id;
            Users = LogicProvider.userLogic.GetAll().Select(user => new UserGetVM(user));
        }
        public UserGetAllVM()
        {
            Users = LogicProvider.userLogic.GetAll().Select(user => new UserGetVM(user));
        }

        public int GetByEmail(string email)
        {
            var user = LogicProvider.userLogic.GetByEmail(email);
            return user.UserId;
        }
        public int GetPhotoId(string email)
        {
            var PhotoId = LogicProvider.userLogic.GetByEmail(email).PictureId;
            return PhotoId;
        }
    }
}