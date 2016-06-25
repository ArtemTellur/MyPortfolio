using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Interfaces
{
    public interface IMyPortfolioDALComment
    {
        Comment GetById(int id);
        int Add(Comment comment);
        IEnumerable<Comment> GetCommentsOfPhoto(int photoId);
        void DeleteCommentsOfUser(int userId);
    }
}
