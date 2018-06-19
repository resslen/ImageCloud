using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models.Files
{
    public class FileViewModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Data przesłania")]
        public DateTime DateOfUpload { get; set; }
        [Display(Name = "Rozmiar")]
        public int Size { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}