using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.DAL
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountOfFiles { get; set; }


        public virtual IList<File> Files { get; set; }
        public virtual IList<Folder> Folders { get; set; }
    }
}