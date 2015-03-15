namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange_3_12_2015 : DbMigration
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
