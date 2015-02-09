namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberViewModelAdded : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberViewModels");
        }
    }
}
