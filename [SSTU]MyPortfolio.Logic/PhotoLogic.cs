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
    public class PhotoLogic : IMyPortfolioLogicPhoto
    {
        private IMyPortfolioDALPhoto DalPhoto = new DBDALPhoto();

        public int Add(Photo photo)
        {
            return DalPhoto.Add(photo);
        }

        public void Delete(int id)
        {
            DalPhoto.Delete(id);
        }

     
        public Photo GetById(int id)
        {
            return DalPhoto.GetById(id);
        }

        public void Update(Photo photo)
        {
            DalPhoto.Update(photo);
        }
        public IEnumerable<int> GetPhotosOfAlbum(int id)
        {
            return DalPhoto.GetPhotosOfAlbum(id).ToArray();
        }
    }
}
