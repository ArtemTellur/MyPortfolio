using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.Entities
{
    public class Photo
    {
        public Photo(string mime, byte[] image)
        {
            Mime = mime;
            Image = image;
        }

        public Photo(string mime, byte[] image, int? albumId)
        {
            Mime = mime;
            Image = image;
            AlbumId = albumId;
        }

        public Photo(int id, string mime, byte[] image, int? albumId)
        {
            Id = id;
            Mime = mime;
            Image = image;
            AlbumId = albumId;
        }

        public int Id { get; set; }

        public string Mime { get; set; }

        public byte[] Image { get; set; }

        public int? AlbumId { get; set; }
    }
}
