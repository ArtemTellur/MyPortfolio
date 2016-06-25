using _SSTU_MyPortfolio.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.Models;
using WebUI.ViewModels;
using WebUI.ViewModels.UserViews;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            string email = User.Identity.Name;
            if (email!="")
            {
                var thisUser = LogicProvider.userLogic.GetByEmail(email);
                return RedirectToAction("UserPage", "User", new { id = thisUser.UserId });
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserLoginVM user, string ReturnUrl)
        {
            if (user.TryLogin(user))
            {
                FormsAuthentication.SetAuthCookie(user.Email, true);
                if (ReturnUrl != null && ReturnUrl != "")
                {
                    return RedirectToAction(ReturnUrl);
                }
                var thisUser = LogicProvider.userLogic.GetByEmail(user.Email);
                return RedirectToAction("UserPage", "User", new { id = thisUser.UserId });
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            string email = User.Identity.Name;
            if (email != "")
            {
                var thisUser = LogicProvider.userLogic.GetByEmail(email);
                return RedirectToAction("UserPage", "User", new { id = thisUser.UserId });
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(UserRegistration user, HttpPostedFileBase uploadImage)
        {
            if (uploadImage == null)
            {
                ModelState.AddModelError("FileError", "Выберите фото");
            }
            if (LogicProvider.userLogic.UserExsist(user.Email))
            {
                ModelState.AddModelError("Email", "E-mail уже существует!");
                return View();
            }
            if (ModelState.IsValid && uploadImage != null)
            {
                int pictureId;
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                pictureId = LogicProvider.photoLogic.Add(new Photo(uploadImage.ContentType, imageData, null));
                LogicProvider.userLogic.Add(new User(user.Name, user.Birthdate, user.About, user.Email, user.Password, 0, pictureId));
                var thisUser = LogicProvider.userLogic.GetByEmail(user.Email);
                return RedirectToAction("UserPage", "User", new { id = thisUser.UserId });
            }
            else return View();
        }

        [Authorize]
        public ActionResult UserPage(int id)
        {
            UserVM userVM = new UserVM(LogicProvider.userLogic.GetById(id));
            return View(userVM);
        }

        [Authorize(Roles = "1")]
        public ActionResult AdminPage(int id)
        {
            var admin = new UserAdminVM(id);
            var Id = LogicProvider.userLogic.GetByEmail(User.Identity.Name).UserId;
            if (id == Id)
            {
                return View(admin);
            }
            return RedirectToAction("AdminPage", "User", new { id = LogicProvider.userLogic.GetByEmail(User.Identity.Name).UserId });
      
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(int id)
        {
            LogicProvider.albumLogic.DeleteAlbumsOfUser(id);
            LogicProvider.commentLogic.DeleteCommentsOfUser(id);
            LogicProvider.userLogic.Delete(id);
            return Json(true, JsonRequestBehavior.DenyGet);
        }

        [Authorize(Roles = "1")]
        public ActionResult Edit(int id, int adminId)
        {
            var user = LogicProvider.userLogic.GetById(id);
            return View(new UsersActionsVM(adminId, new UserAdminPageVM(user)));
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(int adminId, UserAdminPageVM user, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    LogicProvider.photoLogic.Update(new Photo(user.PictureId, uploadImage.ContentType, imageData, null));
                }
                LogicProvider.userLogic.Update(new User(user.Id, user.Name, DateTime.Parse(user.Birthdate), user.About, user.Email, user.Password, user.isAdmin, user.PictureId));
                return RedirectToAction("AdminPage", "User", new { id = adminId });
            }
            return View();
        }

        [Authorize]
        public ActionResult Settings(int id)
        {
            var user = LogicProvider.userLogic.GetById(id);
            var a = LogicProvider.userLogic.GetByEmail(User.Identity.Name);
            if (a.Email == user.Email)
            {
                return View(new UserAdminPageVM(user));
            }
            return RedirectToAction("Settings", "User", new { id = a.UserId });
        }
        [HttpPost]
        [Authorize]
        public ActionResult Settings(UserAdminPageVM user, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    LogicProvider.photoLogic.Update(new Photo(user.PictureId, uploadImage.ContentType, imageData, null));
                }
                LogicProvider.userLogic.Update(new User(user.Id, user.Name, DateTime.Parse(user.Birthdate), user.About, user.Email, user.Password, user.isAdmin, user.PictureId));
                var thisUser = LogicProvider.userLogic.GetByEmail(user.Email);
                return RedirectToAction("UserPage", "User", new { id = thisUser.UserId });
            }
            return View();
        }
        [Authorize]
        public ActionResult GetAll(int id)
        {
            var users = new UserGetAllVM(id);
            return View(users);
        }

        [Authorize]
        public JsonResult Search(string subString)
        {
            var users = LogicProvider.userLogic.GetAll().Select(a => new UserGetVM(a)).Where(a => a.Name.ToLower().IndexOf(subString.ToLower()) == 0);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }

}