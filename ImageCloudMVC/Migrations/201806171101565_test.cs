namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "ParentFolderId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "ParentFolderId", c => c.Int(nullable: false));
        }
    }
}
