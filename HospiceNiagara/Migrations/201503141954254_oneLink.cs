namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        URL = c.String(nullable: false, maxLength: 250),
                        Visible = c.Int(nullable: false),
                        Group = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.LinkHomes");
            DropTable("dbo.LinkStaffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LinkStaffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 250),
                        Visible = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LinkHomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 250),
                        Visible = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Links");
        }
    }
}
