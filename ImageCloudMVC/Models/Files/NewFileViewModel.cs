﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models.Files
{
    public class NewFileViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfUpload { get; set; }
        public int Size { get; set; }
        public int Resolution { get; set; }
        public string Description { get; set; }

    }
}