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
    }
}