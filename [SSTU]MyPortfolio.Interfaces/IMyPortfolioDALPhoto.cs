using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Interfaces
{
    public interface IMyPortfolioDALPhoto
    {
        Photo GetById(int id);
        int Add(Photo photo);
        void Update(Photo photo);
        void Delete(int id);
        IEnumerable<int> GetPhotosOfAlbum(int id);
    }
}
