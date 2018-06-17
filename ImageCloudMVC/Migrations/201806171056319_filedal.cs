namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filedal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "ParentFolderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "ParentFolderId");
        }
    }
}
