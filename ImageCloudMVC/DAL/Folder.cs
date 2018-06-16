using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        public virtual ICollection<File> Files { get; set; }
        public int? ParentFolderId { get; set; }
        public Folder ParentFolder { get; set; }
        [InverseProperty(nameof(ParentFolder))]
        public virtual ICollection<Folder> Folders { get; set; }

        public string UserId { get; set; }
    }
}