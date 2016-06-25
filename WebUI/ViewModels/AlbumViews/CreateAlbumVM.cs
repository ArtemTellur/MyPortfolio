using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels.AlbumViews
{
    public class CreateAlbumVM
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public int UserId { get; set; }

        public CreateAlbumVM(string name, string description, int id)
        {
            Name = name;
            Description = description;
            UserId = id;
        }


        public CreateAlbumVM() { }

    }
}