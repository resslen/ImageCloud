﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.Models
{
    public class AccountListView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfUpload { get; set; }
        public string Size { get; set; }
    }
}