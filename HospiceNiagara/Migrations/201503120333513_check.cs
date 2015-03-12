namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "LinkStaff_ID", "dbo.LinkStaffs");
            DropIndex("dbo.Roles", new[] { "LinkStaff_ID" });
            AddColumn("dbo.Deaths", "Visible", c => c.Int(nullable: false));
            AddColumn("dbo.LinkHomes", "Visible", c => c.Int(nullable: false));
            AddColumn("dbo.LinkStaffs", "Visible", c => c.Int(nullable: false));
            AlterColumn("dbo.LinkHomes", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.LinkHomes", "Link", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.LinkStaffs", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.LinkStaffs", "Link", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Roles", "LinkStaff_ID");
            DropColumn("dbo.Deaths", "isVisible");
            DropColumn("dbo.LinkHomes", "isVisible");
            DropColumn("dbo.LinkStaffs", "isVisible");
            DropColumn("dbo.LinkStaffs", "RoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LinkStaffs", "RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.LinkStaffs", "isVisible", c => c.Boolean(nullable: false));
            AddColumn("dbo.LinkHomes", "isVisible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Deaths", "isVisible", c => c.Int(nullable: false));
            AddColumn("dbo.Roles", "LinkStaff_ID", c => c.Int());
            AlterColumn("dbo.LinkStaffs", "Link", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.LinkStaffs", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.LinkHomes", "Link", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.LinkHomes", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.LinkStaffs", "Visible");
            DropColumn("dbo.LinkHomes", "Visible");
            DropColumn("dbo.Deaths", "Visible");
            CreateIndex("dbo.Roles", "LinkStaff_ID");
            AddForeignKey("dbo.Roles", "LinkStaff_ID", "dbo.LinkStaffs", "ID");
        }
    }
}
