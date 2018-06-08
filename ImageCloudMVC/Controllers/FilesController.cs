using ImageCloudMVC.Models;
using ImageCloudMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCloudMVC.Controllers
{
    public class FilesController : Controller
    {
        private FilesService _filesService;

        public FilesController(FilesService filesService)
        {
            _filesService = filesService;
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
        public ActionResult Add()
        {
            var model = _filesService.GetAddViewModel();
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _filesService.FileById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(NewFileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //filtry
                //dodal service do obslugi bledow
                //ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Add();
            }
            var id = _filesService.AddFile(model);
            return RedirectToAction("Details", new { Id = id });
        }


    }
}