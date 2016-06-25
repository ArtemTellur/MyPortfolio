using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Entities
{
    public class Like
    {
        public Like(int LikeId, int PhotoId, int UserId)
        {
            this.LikeId = LikeId;
            this.PhotoId = PhotoId;
            this.UserId = UserId;
        }
        public Like(int PhotoId, int UserId)
        {
            this.PhotoId = PhotoId;
            this.UserId = UserId;
        }

        public int LikeId { get; set; }
        public int PhotoId { get; set; }
        public int UserId { get; set; }
    }
}
