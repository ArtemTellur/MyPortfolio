using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Interfaces
{
    public interface IMyPortfolioDALLike
    {
        int Add(Like like);
        void Delete(int id);
        IEnumerable<Like> GetLikesOfPhoto(int id);
    }
}
