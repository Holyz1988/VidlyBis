namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Genres", newName: "Genre");
            RenameTable(name: "dbo.Movies", newName: "Movie");
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genre", "Name", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            RenameTable(name: "dbo.Movie", newName: "Movies");
            RenameTable(name: "dbo.Genre", newName: "Genres");
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
