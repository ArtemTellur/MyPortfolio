using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Interfaces
{
    public interface IMyPortfolioLogicUser
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        void Add(User user);
        bool Update(User user);
        void Delete(int id);
        int CalculateAge(DateTime BirthDate);
        bool Login(User user);
        IEnumerable<string> GetRoleForUser(string email);
        IEnumerable<string> GetAllRoles();
        bool UserExsist(string email);
    }
}
