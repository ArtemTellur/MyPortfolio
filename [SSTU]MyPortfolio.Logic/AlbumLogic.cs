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
    public class AlbumLogic : IMyPortfolioLogicAlbum
    {
        private IMyPortfolioDALAlbum DalAlbum = new DBDALAlbum();

        public bool Add(Album album)
        {
            return DalAlbum.Add(album);
        }

        public bool Delete(int id)
        {
            return DalAlbum.Delete(id);
        }

        public IEnumerable<Album> GetAlbumsOfUser(int id)
        {
            return DalAlbum.GetAlbumsOfUser(id);
        }

        public IEnumerable<Album> GetAll()
        {
            return DalAlbum.GetAll().ToArray();
        }

        public Album GetById(int id)
        {
            return DalAlbum.GetById(id);
        }

        public bool Update(Album album)
        {
            return DalAlbum.Update(album);
        }
        public void DeleteAlbumsOfUser(int userId)
        {
            DalAlbum.DeleteAlbumsOfUser(userId);
        }
    }
}
