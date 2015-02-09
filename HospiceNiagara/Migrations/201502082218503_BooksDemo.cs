namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksDemo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Books", newName: "BooksModels");
            CreateTable(
                "dbo.AuthorsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BooksModels", "AuthorsModel_ID", c => c.Int());
            CreateIndex("dbo.BooksModels", "AuthorsModel_ID");
            AddForeignKey("dbo.BooksModels", "AuthorsModel_ID", "dbo.AuthorsModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BooksModels", "AuthorsModel_ID", "dbo.AuthorsModels");
            DropIndex("dbo.BooksModels", new[] { "AuthorsModel_ID" });
            DropColumn("dbo.BooksModels", "AuthorsModel_ID");
            DropTable("dbo.AuthorsModels");
            RenameTable(name: "dbo.BooksModels", newName: "Books");
        }
    }
}
