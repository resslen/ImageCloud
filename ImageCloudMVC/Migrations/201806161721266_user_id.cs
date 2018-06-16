namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Folders", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Folders", "UserId");
            DropColumn("dbo.Files", "UserId");
        }
    }
}
