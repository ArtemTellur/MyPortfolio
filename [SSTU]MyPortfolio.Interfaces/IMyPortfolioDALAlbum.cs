using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Interfaces
{
    public interface IMyPortfolioDALAlbum
    {
        IEnumerable<Album> GetAll();
        Album GetById(int id);
        bool Add(Album album);
        bool Update(Album album);
        bool Delete(int id);
        IEnumerable<Album> GetAlbumsOfUser(int id);
        void DeleteAlbumsOfUser(int userId);
    }
}
