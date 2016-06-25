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
    public class CommentLogic : IMyPortfolioLogicComment
    {
        private IMyPortfolioDALComment DalComment = new DBDALComment();

        public int Add(Comment comment)
        {
            return DalComment.Add(comment);
        }


        public Comment GetById(int id)
        {
            return DalComment.GetById(id);
        }

        public IEnumerable<Comment> GetCommentsOfPhoto(int photoId)
        {
            var comments = DalComment.GetCommentsOfPhoto(photoId).ToArray();
            return comments;
        }

        public void DeleteCommentsOfUser(int userId)
        {
            DalComment.DeleteCommentsOfUser(userId);
        }
    }
}
