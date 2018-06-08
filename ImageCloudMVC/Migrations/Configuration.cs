namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ImageCloudMVC.DAL.ImageCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImageCloudMVC.DAL.ImageCloudContext context)
        {
            //  This method will be called after migrating to the latest version.

        }
    }

}