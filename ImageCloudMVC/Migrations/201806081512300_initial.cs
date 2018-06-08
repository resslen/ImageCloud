namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfUpload = c.DateTime(nullable: false),
                        Size = c.String(),
                        Resolution = c.Int(nullable: false),
                        Description = c.String(),
                        Folder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.Folder_Id)
                .Index(t => t.Folder_Id);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AmountOfFiles = c.Int(nullable: false),
                        Folder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.Folder_Id)
                .Index(t => t.Folder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "Folder_Id", "dbo.Folders");
            DropForeignKey("dbo.Files", "Folder_Id", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "Folder_Id" });
            DropIndex("dbo.Files", new[] { "Folder_Id" });
            DropTable("dbo.Folders");
            DropTable("dbo.Files");
        }
    }
}
