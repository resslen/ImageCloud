using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models.Folders
{
    public class FolderModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountOfFiles { get; set; }
    }
}