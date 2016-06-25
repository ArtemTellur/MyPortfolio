using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UsersActionsVM
    {
        public int AdminId { get; set; }
        public UserAdminPageVM User { get; set; }

        public UsersActionsVM(int adminId, UserAdminPageVM user)
        {
            AdminId = adminId;
            User = user;
            
        }

        public UsersActionsVM()
        {
        }
    }
}