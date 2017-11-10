namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'00bc5846-a413-489b-9484-fef960aea10d', N'guest@vidly.com', 0, N'AEnlhqkW9kVrdovZJxs5UOtZQmwk3jKRjK88A6C1EDCLxXp8nVGwEf7zwRx8A8TSFA==', N'ea1177dc-3e1d-4c1c-8b1d-33222f75fb8b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7e93e5a-4976-4a1d-9fba-92e6773ee163', N'manager@vidly.com', 0, N'AA9wAOc/gSD3ZXHhMc9MSvxQtPCfZj/RNIF5OePkdboQyMAldkRYRqkmbWzy3fZ59Q==', N'e3a81082-20b3-43da-94f2-2c5f875f0eef', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c58b80b2-1ec8-4de6-ad90-82cc2a655768', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7e93e5a-4976-4a1d-9fba-92e6773ee163', N'c58b80b2-1ec8-4de6-ad90-82cc2a655768')


");
        }

        public override void Down()
        {
        }
    }
}
