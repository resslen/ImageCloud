using System.Data.Entity;

namespace ImageCloudMVC.DAL
{
    public class ImageCloudContext : DbContext
    {
        public ImageCloudContext() : base("ImageCloudConnString")
        {}

        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}