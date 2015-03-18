namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class folderChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "FolderName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Folders", "FolderDescription", c => c.String(maxLength: 100));
            DropColumn("dbo.Folders", "FileName");
            DropColumn("dbo.Folders", "FileDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Folders", "FileDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.Folders", "FileName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Folders", "FolderDescription");
            DropColumn("dbo.Folders", "FolderName");
        }
    }
}
