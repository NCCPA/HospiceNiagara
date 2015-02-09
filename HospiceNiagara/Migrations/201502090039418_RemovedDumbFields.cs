namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDumbFields : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FileViewModels");
            DropTable("dbo.MemberViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberViewModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        PhoneExt = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsContact = c.Boolean(nullable: false),
                        CanCreateMeeting = c.Boolean(nullable: false),
                        Position = c.String(),
                        PositionDescription = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
    }
}
