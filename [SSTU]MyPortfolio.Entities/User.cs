using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Entities
{
    public class User
    {
        public User(int UserId, string UserName, DateTime Birthdate, string About, string Email, string Password, int? IsAdmin, int pictureId)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.Birthdate = Birthdate;
            this.About = About;
            this.Email = Email;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
            PictureId = pictureId;
        }

        public User(string UserName, DateTime Birthdate, string About, string Email, string Password, int? IsAdmin, int pictureId)
        {
            this.UserName = UserName;
            this.Birthdate = Birthdate;
            this.About = About;
            this.Email = Email;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
            PictureId = pictureId;
        }
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }


        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Birthdate { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IsAdmin { get; set; }
        public int PictureId { get; set; }
    }
}
