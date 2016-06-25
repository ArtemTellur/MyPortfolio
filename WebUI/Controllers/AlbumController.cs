using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.AlbumViews;
using WebUI.ViewModels.UserViews;

namespace WebUI.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        [Authorize]
        public ActionResult CreateAlbum(int id)
        {
            var user = LogicProvider.userLogic.GetById(id);
            var Id = LogicProvider.userLogic.GetByEmail(User.Identity.Name).UserId;
            if (User.Identity.Name == user.Email)
            {
                CreateAlbumVM newAlbum = new CreateAlbumVM("", "", id);
                return View(newAlbum);
            }
            return RedirectToAction("UserPage", "User", new { id = Id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateAlbum(CreateAlbumVM newAlbum)
        {
            LogicProvider.albumLogic.Add(new Album(newAlbum.Name, newAlbum.Description, newAlbum.UserId));
            return RedirectToAction("UserPage", "User", new { id = newAlbum.UserId });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, int userId)
        {
            var userEmail = LogicProvider.userLogic.GetAll().Select(a => new UserVM(a)).Where(a => a.Id == userId).First().Email;
            if (User.Identity.Name == userEmail)
            {
                LogicProvider.albumLogic.Delete(id);
                return Json(true, JsonRequestBehavior.DenyGet);
            }
            return Json(false, JsonRequestBehavior.DenyGet);
        }

        [Authorize]
        public ActionResult AlbumPage(int id)
        {
            var album = new AlbumVM(LogicProvider.albumLogic.GetById(id));
            return View(album);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UploadImages(HttpPostedFileBase[] uploadImages, int albumId)
        {
            foreach (var uploadImage in uploadImages)
            {
                int pictureId;
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                pictureId = LogicProvider.photoLogic.Add(new Photo(uploadImage.ContentType, imageData, albumId));
            }
            return RedirectToAction("AlbumPage", new { id = albumId});
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var album = LogicProvider.albumLogic.GetById(id);
            var userEmail = LogicProvider.userLogic.GetById(album.UserId).Email;
            var Id = LogicProvider.userLogic.GetByEmail(User.Identity.Name).UserId;
            if (User.Identity.Name == userEmail)
            {
                return View(new AlbumVM(album));
            }
            return RedirectToAction("UserPage", "User", new { id = Id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(AlbumVM album)
        {
            if (ModelState.IsValid)
            {
                var userId = album.UserId;
                LogicProvider.albumLogic.Update(new Album(album.AlbumId, album.Name, album.Description, userId));
                return RedirectToAction("UserPage", "User", new { id = userId});
            }
            return View();
        }

    }
}