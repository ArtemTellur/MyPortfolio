using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserAdminPageVM
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public string Birthdate { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "О себе")]
        public string About { get; set; }
        [Display(Name = "Админ")]
        public int? isAdmin { get; set; }

        public int PictureId { get; set; }

        public UserAdminPageVM(User user)
        {
            Id = user.UserId;
            Name = user.UserName;
            Birthdate = user.Birthdate.ToString("yyyy-MM-dd");
            Age = LogicProvider.userLogic.CalculateAge(DateTime.Parse(Birthdate));
            Email = user.Email;
            Password = user.Password;
            About = user.About;
            isAdmin = user.IsAdmin;          
            PictureId = user.PictureId;
        }
        public UserAdminPageVM()
        {

        }
        public int GetByEmail(string email)
        {
            var user = LogicProvider.userLogic.GetByEmail(email);
            return user.UserId;
        }
    }
}