namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDate_toAnnouncements : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "Date");
        }
    }
}
