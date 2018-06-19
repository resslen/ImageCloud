using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCloudMVC.DAL
{
    public class News
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String ImageName { get; set; }
        public String BodyText { get; set; }
    }
}