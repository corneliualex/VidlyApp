namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGendre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Gendres(Id,Name) VALUES(1,'Action')");
            Sql("INSERT INTO Gendres(Id,Name) VALUES(2,'Comedy')");
            Sql("INSERT INTO Gendres(Id,Name) VALUES(3,'Horror')");
            Sql("INSERT INTO Gendres(Id,Name) VALUES(4,'Adventure')");
        }
        
        public override void Down()
        {
        }
    }
}
