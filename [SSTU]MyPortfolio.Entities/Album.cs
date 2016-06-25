using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Entities
{
    public class Album
    {
        public Album(int AlbumId, string AlbumName, string Description, int UserId)
        {
            this.AlbumId = AlbumId;
            this.AlbumName = AlbumName;
            this.Description = Description;
            this.UserId = UserId;
        }

        public Album(string AlbumName, string Description, int UserId)
        {
            this.AlbumName = AlbumName;
            this.Description = Description;
            this.UserId = UserId;
        }

        public int AlbumId { get; set; }
        public int UserId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
    }
}
