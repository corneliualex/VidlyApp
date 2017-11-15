namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhoneToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
