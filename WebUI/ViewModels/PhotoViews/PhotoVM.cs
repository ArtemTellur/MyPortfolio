using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels.PhotoViews
{
    public class PhotoVM
    {
        public PhotoVM(string mime, byte[] image)
        {
            Mime = mime;
            Image = image;
        }

        public PhotoVM(string mime, byte[] image, int? albumId)
        {
            Mime = mime;
            Image = image;
            AlbumId = albumId;
        }

        public PhotoVM(int id, string mime, byte[] image, int? albumId)
        {
            Id = id;
            Mime = mime;
            Image = image;
            AlbumId = albumId;
        }
        public PhotoVM(Photo photo)
        {
            Id = photo.Id;
            Mime = photo.Mime;
            Image = photo.Image;
            AlbumId = photo.AlbumId;
        }

        public PhotoVM()
        {
        }

        public int Id { get; set; }

        public string Mime { get; set; }

        public byte[] Image { get; set; }

        public int? AlbumId { get; set; }
    }
}