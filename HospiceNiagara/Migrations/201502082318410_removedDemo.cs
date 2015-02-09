namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedDemo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BooksModels", "AuthorsModel_ID", "dbo.AuthorsModels");
            DropIndex("dbo.BooksModels", new[] { "AuthorsModel_ID" });
            DropTable("dbo.AuthorsModels");
            DropTable("dbo.BooksModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BooksModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Year = c.String(),
                        AuthorsModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AuthorsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.BooksModels", "AuthorsModel_ID");
            AddForeignKey("dbo.BooksModels", "AuthorsModel_ID", "dbo.AuthorsModels", "ID");
        }
    }
}
