namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid_int_toString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "UserId", c => c.String());
            AlterColumn("dbo.Folders", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Folders", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "UserId", c => c.Int(nullable: false));
        }
    }
}
