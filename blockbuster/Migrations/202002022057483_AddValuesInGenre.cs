namespace blockbuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuesInGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id, Name) values(1,'Comedy')");
            Sql("Insert into Genres(Id, Name) values(2,'Horror')");
            Sql("Insert into Genres(Id, Name) values(3,'Thriller')");
            Sql("Insert into Genres(Id, Name) values(4,'Sci-Fi')");
            Sql("Insert into Genres(Id, Name) values(5,'Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
