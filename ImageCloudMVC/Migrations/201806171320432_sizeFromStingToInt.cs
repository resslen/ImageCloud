namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizeFromStingToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "Size", c => c.String());
        }
    }
}
