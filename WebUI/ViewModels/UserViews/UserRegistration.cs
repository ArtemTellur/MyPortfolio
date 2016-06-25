using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.ViewModels.UserViews
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Укажите имя")]
        [RegularExpression(@"[а-яА-ЯёЁa-zA-Z]{3,14}", ErrorMessage = "Имя должно содержать только буквы и быть от 3 до 14 символов!")]
        [Display(Name = "Имя")]
        [MinLength(3)]
        [MaxLength(14)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Укажите E-mail")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail указан неверно")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Укажите информацию о себе")]
        [Display(Name = "О себе")]
        public string About { get; set; }

        public int PictureId { get; set; }

        public UserRegistration(_SSTU_MyPortfolio.Entities.User user)
        {
            Name = user.UserName;
            Birthdate = user.Birthdate;
            Email = user.Email;
            Password = user.Password;
            About = user.About;
            PictureId = user.PictureId;
        }
        public UserRegistration()
        {
            
        }
    }
}