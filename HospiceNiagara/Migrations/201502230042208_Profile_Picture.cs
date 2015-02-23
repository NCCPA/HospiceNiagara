namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile_Picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.Binary(nullable: false));
            AddColumn("dbo.AspNetUsers", "MimeType", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MimeType");
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
    }
}
