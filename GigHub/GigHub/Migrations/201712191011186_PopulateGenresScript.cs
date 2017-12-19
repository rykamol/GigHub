namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresScript : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT Into Genres(Id,Name)Values(1,'Juzz')");
            Sql("INSERT Into Genres(Id,Name)Values(2,'Bengeli')");
            Sql("INSERT Into Genres(Id,Name)Values(3,'Blues')");
            Sql("INSERT Into Genres(Id,Name)Values(4,'Rock')");
            Sql("INSERT Into Genres(Id,Name)Values(5,'Country')");
        }
        
        public override void Down()
        {
            Sql("DELETE FORM Genres WHERE Id IN (1,2,3,4,5)");
        }
    }
}
