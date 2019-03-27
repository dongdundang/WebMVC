using BUS;
using DTO;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Helpers;

namespace WebMVC.Controllers
{
    public class AlbumController : Controller
    {
        [HttpGet]
        public JsonResult GetAll()
        {
            using (AlbumRepository rep = new AlbumRepository())
            {
                return Json(rep.Get(x=>x.Activate == true), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (AlbumRepository rep = new AlbumRepository())
            {
                var album = rep.GetById(id);
                if (album != null)
                {
                    album.Activate = false;
                    rep.Update(album);
                    return Json(album.Id);
                }
                return Json(-1);
            }
        }

        [HttpGet]
        public JsonResult GetAlbumById(int id)
        {
            using (AlbumRepository rep = new AlbumRepository())
            {
                var album = rep.Get(x => x.Activate == true && x.Id == id).First();
                return Json(album, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Update(Album model)
        {
            if (Validate(model))
            {
                using (AlbumRepository rep = new AlbumRepository())
                {
                    var album = rep.GetById(model.Id);
                    album.Name = model.Name;

                    var currentUser = UserHelper.GetCurrentUser();
                    album.ModifiedById = currentUser.Id;
                    album.ModifiedByName = string.Format("{0} {1}", currentUser.LastName, currentUser.FirstName);
                    album.ModifiedDate = DateTime.Now;
                    rep.Update(album);

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        var fileExtension = Path.GetExtension(file.FileName);
                        var fileName = string.Format("{0}{1}", model.Id, fileExtension);
                        var path = Path.Combine(Server.MapPath("~/Images/Upload/Album"), fileName);
                        file.SaveAs(path);
                    }
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(-1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNewAlbum()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddNewAlbum(Album model)
        {
            if (Validate(model))
            {
                var currentUser = UserHelper.GetCurrentUser();

                model.CreatedById = currentUser.Id;
                model.CreatedByName = string.Format("{0} {1}", currentUser.LastName, currentUser.FirstName);
                model.CreatedDate = DateTime.Now;

                using (AlbumRepository repository = new AlbumRepository())
                {
                    repository.Insert(model);

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileExtension = Path.GetExtension(file.FileName);
                            var fileName = string.Format("{0}{1}", model.Id, fileExtension);
                            var path = Path.Combine(Server.MapPath("~/Images/Upload/Album"), fileName);
                            file.SaveAs(path);

                            model.Image = Config.UploadAlbumCoverPath + fileName;
                            repository.Update(model);
                        }
                    }

                    TempData["Message"] = "New Album added successfully";
                    TempData["MessageType"] = "success";

                    return RedirectToAction("Index", "Album");
                }
            }
            return View(model);
        }

        private bool Validate(Album album)
        {
            return !string.IsNullOrEmpty(album.Name);
        }
    }
}