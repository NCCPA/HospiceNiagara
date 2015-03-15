namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ProfilePicture", c => c.Binary());
            AlterColumn("dbo.AspNetUsers", "MimeType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "MimeType", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "ProfilePicture", c => c.Binary(nullable: false));
        }
    }
}
