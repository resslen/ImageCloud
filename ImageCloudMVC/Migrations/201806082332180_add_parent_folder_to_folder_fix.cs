namespace ImageCloudMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_parent_folder_to_folder_fix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Folders", name: "FolderId", newName: "ParentFolderId");
            RenameIndex(table: "dbo.Folders", name: "IX_FolderId", newName: "IX_ParentFolderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Folders", name: "IX_ParentFolderId", newName: "IX_FolderId");
            RenameColumn(table: "dbo.Folders", name: "ParentFolderId", newName: "FolderId");
        }
    }
}
