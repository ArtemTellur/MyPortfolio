using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserLoginVM(User user)
        {
            Email = user.Email;
            Password = user.Password;
        }
        public UserLoginVM()
        {

        }

        public bool TryLogin(UserLoginVM user)
        {
            return LogicProvider.userLogic.Login(new User(user.Email, user.Password));
        }
    }
}