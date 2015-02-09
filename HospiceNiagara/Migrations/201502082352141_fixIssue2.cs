namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixIssue2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        folderID = c.Int(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileDescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileViewModels");
        }
    }
}
