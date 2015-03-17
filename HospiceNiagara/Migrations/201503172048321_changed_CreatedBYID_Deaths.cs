namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_CreatedBYID_Deaths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deaths", "CreatedByID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Deaths", "CreatedByID", c => c.Int(nullable: false));
        }
    }
}
