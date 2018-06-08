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
        //[Route("files")]
        public ActionResult Files()
        {
            var model = _filesService.GetFiles();
            return View(model);
        }

        [HttpGet]
        [Route("files/root")]
        public ActionResult FilesRoot()
        {
            var model = _filesService.GetRootFiles();
            return View(model);
        }

        [HttpGet, Route("add")]
        public ActionResult Add()
        {
            var model = _filesService.GetRootFiles();
            return View(model);
        }

    }
}