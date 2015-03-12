namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deaths", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Deaths", "Note", c => c.String(maxLength: 200));
            AlterColumn("dbo.Deaths", "isVisible", c => c.Int(nullable: false));
            DropColumn("dbo.DeathPrivacies", "DeathID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeathPrivacies", "DeathID", c => c.Int(nullable: false));
            AlterColumn("dbo.Deaths", "isVisible", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Deaths", "Note", c => c.String(maxLength: 100));
            AlterColumn("dbo.Deaths", "Date", c => c.DateTime());
        }
    }
}
