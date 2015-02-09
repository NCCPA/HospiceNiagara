namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksDemo3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BookDetail_ID", "dbo.BooksModels");
            DropIndex("dbo.AspNetUsers", new[] { "BookDetail_ID" });
            DropColumn("dbo.AspNetUsers", "BookDetail_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BookDetail_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BookDetail_ID");
            AddForeignKey("dbo.AspNetUsers", "BookDetail_ID", "dbo.BooksModels", "ID");
        }
    }
}
