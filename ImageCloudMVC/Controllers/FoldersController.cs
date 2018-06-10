using ImageCloudMVC.Models.Folders;
using ImageCloudMVC.Services;
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
            var model = _foldersService.GetFolderById(1);
            return View(model);
        }

        [HttpGet]
        public ActionResult Subfolder(int id)
        {
            var model = _foldersService.GetFolderById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = _foldersService.GetAddViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewFolderViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                //filtry
                //dodal service do obslugi bledow
                //ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Create();
            }
            model.ParentFolderId = id;
            _foldersService.AddFolder(model);
            return RedirectToAction("Subfolder", new { Id = id});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _foldersService.Delete(id);
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
            _foldersService.UpdateFolder(id, model);
            return RedirectToAction("Index");
        }
    }
}