namespace blockbuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab1d12be-4940-4a79-b957-20a2a71f178b', N'admin@blockbuster.com', 0, N'AJMyb8m8j6dTlVZDcjp5pUl2oJ9DXWhVhmoi43MhmobHVwT8Q364l/AkVBOwFmKPVg==', N'd6964afc-68f2-4d20-8eb2-81297bbf6c47', NULL, 0, 0, NULL, 1, 0, N'admin@blockbuster.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b4a71acf-d37d-4565-91fc-05e4f4d53787', N'guest@blockbuster.com', 0, N'AK7IBno9Pqq63z8VU0dTEXcYeF1h3ZpmhP91aZG0cc5re9ey1QKh7IapmQ1DlfwBXg==', N'e964495f-d1bd-410b-950b-1da84cbab8de', NULL, 0, 0, NULL, 1, 0, N'guest@blockbuster.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e5f39578-f96f-4117-96de-7901deb8a087', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ab1d12be-4940-4a79-b957-20a2a71f178b', N'e5f39578-f96f-4117-96de-7901deb8a087')

");
        }
        
        public override void Down()
        {
        }
    }
}
