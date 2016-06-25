using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.ViewModels.AlbumViews
{
    public class AlbumVM
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int AlbumId { get; set; }

        public IEnumerable<int> PhotosId { get; set; }

        public AlbumVM(int albumId, string name, string description, int userId)
        {
            AlbumId = albumId;
            Name = name;
            Description = description;
            UserId = userId;
            PhotosId = LogicProvider.photoLogic.GetPhotosOfAlbum(AlbumId);
        }

        public AlbumVM(Album album)
        {
            AlbumId = album.AlbumId;
            Name = album.AlbumName;
            Description = album.Description;
            UserId = album.UserId;
            PhotosId = LogicProvider.photoLogic.GetPhotosOfAlbum(AlbumId);
        }

        public AlbumVM() { }

        public string GetEmail(int id)
        {
            return LogicProvider.userLogic.GetById(id).Email;
        }
        public string GetName(int id)
        {
            return LogicProvider.userLogic.GetById(id).UserName;
        }
        public int GetByEmail(string email)
        {
            return LogicProvider.userLogic.GetByEmail(email).UserId;
        }
        public int GetPhotoId(string email)
        {
            var PhotoId = LogicProvider.userLogic.GetByEmail(email).PictureId;
            return PhotoId;
        }
    }
}