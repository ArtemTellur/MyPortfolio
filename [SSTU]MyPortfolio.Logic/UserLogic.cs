using _SSTU_MyPortfolio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SSTU_MyPortfolio.Entities;
using _SSTU_MyPortfolio.DAL.DB;

namespace _SSTU_MyPortfolio.Logic
{
    public class UserLogic : IMyPortfolioLogicUser
    {
        private IMyPortfolioDALUser DalUser = new DBDALUser();

        public void Add(User user)
        {
            DalUser.Add(user);
        }

        public void Delete(int id)
        {
            DalUser.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return DalUser.GetAll().ToArray();
        }

        public User GetById(int id)
        {
            return DalUser.GetById(id);
        }

        public bool Update(User user)
        {
            return DalUser.Update(user);
        }

        public int CalculateAge(DateTime BirthDate)
        {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
        public bool Login(User user)
        {
            return DalUser.Login(user);
        }

        public User GetByEmail(string email)
        {
            return DalUser.GetByEmail(email);
        }

        public IEnumerable<string> GetRoleForUser(string email)
        {
            return DalUser.GetRoleForUser(email).ToArray();
        }

        public IEnumerable<string> GetAllRoles()
        {
            return DalUser.GetAllRoles().ToArray();
        }

        public bool UserExsist(string email)
        {
            var user = DalUser.GetByEmail(email);
            return user != null;
        }
       
    }
}
