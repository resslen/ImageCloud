using ImageCloudMVC.DAL;
using ImageCloudMVC.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models.Folders
{
    public class FolderListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountOfFiles { get; set; }

        public virtual ICollection<FileModel> Files { get; set; }
        public virtual ICollection<FolderModel> Folders { get; set; }
    }
}