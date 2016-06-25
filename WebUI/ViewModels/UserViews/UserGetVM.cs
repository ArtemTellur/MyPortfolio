using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserGetVM
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }     

        public int PictureId { get; set; }

        public UserGetVM(User user)
        {
            Id = user.UserId;
            Name = user.UserName;
            Age = LogicProvider.userLogic.CalculateAge(user.Birthdate);
            Email = user.Email;
            PictureId = user.PictureId;
        }
    }
}