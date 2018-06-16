using ImageCloudMVC.Models.Folders;
using ImageCloudMVC.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCloudMVC.Controllers
{
    public class FoldersController : Controller
    {
        private FoldersService _foldersService;

        public FoldersController(FoldersService foldersService)
        {
            _foldersService = foldersService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var rootId = _foldersService.GetRootId(userId);
            var model = _foldersService.GetFolderById(rootId, userId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Subfolder(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _foldersService.GetFolderById(id, userId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = _foldersService.GetAddViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewFolderViewModel model, int? id)
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
            model.ParentFolderId = id;
            _foldersService.AddFolder(model, userId);
            return RedirectToAction("Subfolder", new { Id = id});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            _foldersService.Delete(id, userId);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _foldersService.GetEditViewModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditFolderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //filtry
                //dodal service do obslugi bledow
                //ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Edit(id);
            }
            var userId = User.Identity.GetUserId();
            _foldersService.UpdateFolder(id, model, userId);
            return RedirectToAction("Index");
        }
    }
}