namespace storev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [PhoneNum]) VALUES (N'a16c7962-79f5-4e15-b812-9160a843cfab', N'admin@weeat.com', 0, N'AGO2fuyGftjTHDJxGcToRsJLfp7+bLyUvAapfyuPossAp/yEDdR7BGk4xhAh6rm6VQ==', N'105c0aee-3bfc-4ba1-94f3-982c9e42c502', NULL, 0, 0, NULL, 1, 0, N'admin@weeat.com', N'Admins', N'0795716713')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [PhoneNum]) VALUES (N'a823209e-2f16-440a-b608-b00b5753b374', N'user@weeat.com', 0, N'ALs4+uXBzYYulBcHOIonrAeWRKL+oHeOoMG4gETZu3K7P/um3CVE1/eia3cbXfgitA==', N'887cd6c5-b9e0-4899-831e-89b3918a0124', NULL, 0, 0, NULL, 1, 0, N'user@weeat.com', N'Users', N'0795716713')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'52422271-8e23-4e0e-b0a4-389669423c3c', N'Admin')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a16c7962-79f5-4e15-b812-9160a843cfab', N'52422271-8e23-4e0e-b0a4-389669423c3c')
           ");
        }
        
        public override void Down()
        {
        }
    }
}
