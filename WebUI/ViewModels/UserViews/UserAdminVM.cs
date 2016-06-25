using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserAdminVM
    {
        public IEnumerable<UserAdminPageVM> Users { get; set; }
        public int Id { get; set; }

        public UserAdminVM(int id)
        {
            Id = id;
            Users = LogicProvider.userLogic.GetAll().Select(user => new UserAdminPageVM(user));
        }
        public UserAdminVM()
        {
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
        public string GetName(int id)
        {
            return LogicProvider.userLogic.GetById(id).UserName;
        }
    }
}