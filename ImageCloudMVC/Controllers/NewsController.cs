using ImageCloudMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCloudMVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly ImageCloudContext _context;


        public NewsController(ImageCloudContext context)
        {
            _context = context;
        }

        // GET: News
        public ActionResult Index()
        {
            return View(_context.News.ToList());
        }
    }
}