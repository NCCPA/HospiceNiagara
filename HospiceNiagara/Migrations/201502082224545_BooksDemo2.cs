namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksDemo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BookDetail_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BookDetail_ID");
            AddForeignKey("dbo.AspNetUsers", "BookDetail_ID", "dbo.BooksModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BookDetail_ID", "dbo.BooksModels");
            DropIndex("dbo.AspNetUsers", new[] { "BookDetail_ID" });
            DropColumn("dbo.AspNetUsers", "BookDetail_ID");
        }
    }
}
