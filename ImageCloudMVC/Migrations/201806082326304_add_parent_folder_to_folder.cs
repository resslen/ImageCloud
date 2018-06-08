namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_parent_folder_to_folder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Folders", name: "Folder_Id", newName: "FolderId");
            RenameIndex(table: "dbo.Folders", name: "IX_Folder_Id", newName: "IX_FolderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Folders", name: "IX_FolderId", newName: "IX_Folder_Id");
            RenameColumn(table: "dbo.Folders", name: "FolderId", newName: "Folder_Id");
        }
    }
}
