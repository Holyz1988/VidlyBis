namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genre (Id, Name) VALUES ('1', 'Comedy')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('2', 'Horror')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('3', 'Drame')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('4', 'Anime')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('5', 'Documentary')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('6', 'Thriller')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('7', 'Suspens')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('8', 'Fantastic')");
            Sql("INSERT INTO Genre (Id, Name) VALUES ('9', 'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
