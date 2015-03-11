namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "SubRole_ID", "dbo.SubRoles");
            DropIndex("dbo.Roles", new[] { "SubRole_ID" });
            DropColumn("dbo.Roles", "SubRole_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "SubRole_ID", c => c.Int());
            CreateIndex("dbo.Roles", "SubRole_ID");
            AddForeignKey("dbo.Roles", "SubRole_ID", "dbo.SubRoles", "ID");
        }
    }
}
