using ImageCloudMVC.Models.Files;
using ImageCloudMVC.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCloudMVC.Controllers
{
    public class FilesController : Controller
    {
        private FilesService _filesService;
        private FoldersService _foldersService;

        public FilesController(FilesService filesService, FoldersService foldersService)
        {
            _filesService = filesService;
            _foldersService = foldersService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _filesService.GetFiles();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilesRoot()
        {
            var model = _filesService.GetRootFiles();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _filesService.FileById(id, userId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = _filesService.GetAddViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewFileViewModel model, int? id)
        {
            if (!ModelState.IsValid)
            {
                //filtry
                //dodal service do obslugi bledow
                //ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Create();
            }
            var userId = User.Identity.GetUserId();
            if (id == null) { id = _foldersService.GetRootId(userId); }
            var id_file = _filesService.AddFile(model, userId, id);
            return RedirectToAction("Details", new { Id = id_file });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            _filesService.Delete(id, userId);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _filesService.GetEditViewModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditFileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //filtry
                //dodal service do obslugi bledow
                //ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Edit(id);
            }
            var userId = User.Identity.GetUserId();
            _filesService.UpdateFile(id, model,userId);
            return RedirectToAction("Details", new { Id = id });
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files, int? id)
        {
            var userId = User.Identity.GetUserId();
            if (id == null) { var myId = _foldersService.GetRootId(userId); }
            _filesService.UploadFiles(files, id, userId);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}