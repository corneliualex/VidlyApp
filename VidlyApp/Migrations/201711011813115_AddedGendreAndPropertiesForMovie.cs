namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGendreAndPropertiesForMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        NumberInStock = c.Short(nullable: false),
                        GendreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gendres", t => t.GendreId, cascadeDelete: true)
                .Index(t => t.GendreId);
            
            CreateTable(
                "dbo.Gendres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GendreId", "dbo.Gendres");
            DropIndex("dbo.Movies", new[] { "GendreId" });
            DropTable("dbo.Gendres");
            DropTable("dbo.Movies");
        }
    }
}
