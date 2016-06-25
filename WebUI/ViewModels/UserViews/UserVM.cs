using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;
using WebUI.ViewModels.AlbumViews;

namespace WebUI.ViewModels.UserViews
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public string About { get; set; }

        public int PictureId { get; set; }

        public IEnumerable<AlbumVM> Albums { get; set; }

        public UserVM(User user)
        {
            Id = user.UserId;
            Name = user.UserName;
            Birthdate = user.Birthdate;
            Age = LogicProvider.userLogic.CalculateAge(Birthdate);
            Email = user.Email;
            About = user.About;
            PictureId = user.PictureId;
            Albums = LogicProvider.albumLogic.GetAlbumsOfUser(Id).Select(a => new AlbumVM(a));
        }

        public string Email { get; set; }

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