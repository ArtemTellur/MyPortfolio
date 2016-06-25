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
    public class LikeLogic : IMyPortfolioLogicLike
    {
        private IMyPortfolioDALLike DalLike = new DBDALLike();

        public int Add(Like like)
        {
            return DalLike.Add(like);
        }

        public void Delete(int id)
        {
            DalLike.Delete(id);
        }

        public IEnumerable<Like> GetLikesOfPhoto(int id)
        {
            return DalLike.GetLikesOfPhoto(id).ToArray();
        }
    }
}
