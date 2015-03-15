namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange_31215 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeathPrivacies", "DeathID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeathPrivacies", "DeathID");
        }
    }
}
