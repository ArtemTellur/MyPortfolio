using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Entities
{
    public class Comment
    {
        public Comment(int CommentId, string Text, int PhotoId, int userId)
        {
            this.CommentId = CommentId;
            this.Text = Text;
            this.PhotoId = PhotoId;
            this.UserId = userId;
        }
        public Comment(string Text, int photoId, int userId)
        {
            this.PhotoId = photoId;
            this.Text = Text;
            this.UserId = userId;
        }

        public int CommentId { get; set; }
        public int PhotoId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}
