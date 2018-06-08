using ImageCloudMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Services
{
    public class FoldersService
    {
        private readonly ImageCloudContext _context;

        public FoldersService(ImageCloudContext context)
        {
            _context = context;
        }

        /*
        public IEnumerable<FolderListViewModel> GetFolders(string sort = null, string search = null)
        {
            
        }
        */
    }
}