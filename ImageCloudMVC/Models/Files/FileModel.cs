﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models.Files
{
    public class FileModel
    {
        public string Name { get; set; }
        public DateTime DateOfUpload { get; set; }
        public string Size { get; set; }
        public int Resolution { get; set; }
        public string Description { get; set; }
    }
}